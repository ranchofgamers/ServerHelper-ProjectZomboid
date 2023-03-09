using Discord;
using Discord.WebSocket;
using ServerHelper.Core.DiscordBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot
{
    public class BotShell
    {
        public event Action Connected;
        public event Action<Exception> Disconnected;
        public event Action<SocketMessage> MessageReceived;
        public event Action<LogMessage> Log;

        public bool IsOnline { get; private set; }
        public bool IsConnecting { get; private set; }
        public bool IsDisconnecting { get; private set; }
        public bool IsCommandsHandling { get; private set; }
        public ulong ServerID { get; private set; }
        public string Token { get; private set; }
        public CommandsList CommandsList { get; private set; }

        private DiscordSocketClient client;
        private Queue<PendingCommand> pendingCommandsQueue;
        private object pandingCommandsLocker = new object();
        private object botStateLocker = new object();
        private Task CommandHandlerTask;
        private CancellationTokenSource handlerTaskCTS;

        public BotShell(string token, ulong serverId, string commandsFilePath)
        {
            Token = token;
            ServerID = serverId;

            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent,
            };
            client = new DiscordSocketClient();
            client = new DiscordSocketClient(config);

            CommandsList = new CommandsList(commandsFilePath);

            pendingCommandsQueue = new Queue<PendingCommand>();

            client.Connected += ConnectedHandler;
            client.Disconnected += DisconnectedHandler;
            client.MessageReceived += CommandsHandler;
            client.Log += LogHandler;
        }

        #region Публичные методы
        public async Task RunAsync()
        {
            if (IsConnecting)
                throw new InvalidOperationException("Отказано в доступе, бот уже пытается подключиться");

            if (IsOnline)
                throw new InvalidOperationException("Бот уже подключен");

            IsConnecting = true;
           
            RunCommandHandler();

            await client.LoginAsync(TokenType.Bot, Token);
            await client.StartAsync();
        }
        public async Task StopAsync()
        {
            if (IsDisconnecting)
                throw new InvalidOperationException("Отказано в доступе, бот уже пытается отключиться");

            if (!IsOnline)
                throw new InvalidOperationException("Бот не подключен");

            IsDisconnecting = true;

            await client.StopAsync();
        }
        public async Task ResetStateAsync()
        {
            await client.LogoutAsync();
            await client.StopAsync();

            lock (botStateLocker)
            {
                IsOnline = false;
                IsConnecting = false;
                IsDisconnecting = false;
                IsCommandsHandling = false;

                handlerTaskCTS.Cancel();
                pendingCommandsQueue.Clear();
            }
        }
        public void UpdateInfo(string token = default, ulong serverId = default, string commandsFilePath = default)
        {
            if (IsOnline)
                throw new InvalidOperationException("Отказано в доступе, не возможно обновить информацию о подключении пока бот онлайн");

            if (IsConnecting || IsDisconnecting)
                throw new InvalidOperationException("Отказано в доступе, не возможно обновить информацию о подключении, бот уже работает с подключением");

            if(token != default)
                Token = token;
            if (serverId != default)
                ServerID = serverId;
            if (commandsFilePath != default)
                CommandsList.DeserializeCommandsFromJson();
        }
        public bool AddCommandInQueue(string name, object[] args, object sender)
        {
            var com = CommandsList.Commands.Find(c => c.Config.Name.ToLower() == name.ToLower());
            if (com == null)
            {
                LogHandler(new LogMessage(LogSeverity.Info, "[Commands Queue]", $"Команда {name} не зарегистрирована"));
                return false;
            }

            AddCommandInQueue(name, () => { com.FromCodeHandler(this, args); }, sender);
            return true;
        }
        public async Task SendMessageAsync(ulong channelId, string message)
        {
            var guild = client.Guilds.Single(g => g.Id == ServerID);
            var channel = guild.TextChannels.Single(ch => ch.Id == channelId);
            await channel.SendMessageAsync(message);

        }
        public async Task SendFileAsync(ulong channelId, string filepath, string message = "")
        {
            var guild = client.Guilds.Single(g => g.Id == ServerID);
            var channel = guild.TextChannels.Single(ch => ch.Id == channelId);
            await channel.SendFileAsync(filepath, message);
        }
        public SocketGuild GetGuild()
        {
            return client.Guilds.Single(g => g.Id == ServerID);
        }
        #endregion

        #region Приватные методы
        private void RunCommandHandler()
        {
            handlerTaskCTS = new CancellationTokenSource();

            CommandHandlerTask = new Task(async () =>
            {
                try
                {
                    while (true)
                    {
                        if (handlerTaskCTS.IsCancellationRequested)
                            handlerTaskCTS.Token.ThrowIfCancellationRequested();

                        if (pendingCommandsQueue.Count > 0 && !IsCommandsHandling)
                        {
                            try { HandleAllCommands(); }
                            catch (CommandsHandlingException ex) { await LogHandler(new LogMessage(LogSeverity.Error, "[Commands Handler]", "Возникли исключения при обработке команд", ex)); }
                        }
                        else Thread.Sleep(1);
                    }
                }
                catch (OperationCanceledException ex)
                {
                    await LogHandler(new LogMessage(LogSeverity.Info, "[Commands Handler]", "Обработчик команд успешно остановлен", ex));
                }
                catch (Exception e)
                {
                    await ResetStateAsync();
                    Disconnected?.Invoke(e);
                    await LogHandler(new LogMessage(LogSeverity.Error, "[Commands Handler]", "Возникло непредвиденное исключение, состояние бота сброшено, бот отключен", e));
                }

            }, handlerTaskCTS.Token);

            CommandHandlerTask.Start();
        }
        private void HandleAllCommands(CommandsHandlingException exception = null)
        {
            IsCommandsHandling = true;
            PendingCommand com = null;
            try
            {
                lock (pandingCommandsLocker)
                {
                    while (pendingCommandsQueue.Count > 0)
                    {
                        com = pendingCommandsQueue.Dequeue();
                        com.Handler?.Invoke();
                        LogHandler(new LogMessage(LogSeverity.Info, "[Commands Queue]", $"Команда [{com.Name}] от [{com.Sender}] отправлена на обработку"));
                    }
                    if (exception != null)
                        throw exception;
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(CommandsHandlingException))
                    throw;
                else if (exception == null)
                    HandleAllCommands(new CommandsHandlingException().AddUnfulfilledCommand(com, ex));
                else
                    HandleAllCommands(exception.AddUnfulfilledCommand(com, ex));
            }
            finally { IsCommandsHandling = false; }
        }
        private void AddCommandInQueue(string name, Action command, object sender)
        {
            lock (pandingCommandsLocker)
            {
                var pc = new PendingCommand(name, command, sender);
                pendingCommandsQueue.Enqueue(pc);
                LogHandler(new LogMessage(LogSeverity.Info, "[Commands Queue]", $"Команда [{name}] поставлена в очередь, вызвал [{sender}]"));
                return;
            }
        }
        #endregion

        #region Обработчики событий бота
        private Task ConnectedHandler()
        {
            IsConnecting = false;
            IsOnline = true;
            Connected?.Invoke();
            return Task.CompletedTask;
        }
        private Task DisconnectedHandler(Exception ex)
        {
            _ = ResetStateAsync();
            Disconnected?.Invoke(ex);
            return Task.CompletedTask;
        }
        private Task CommandsHandler(SocketMessage msg)
        {
            MessageReceived?.Invoke(msg);

            if (msg == null || msg.Author.IsBot)
                return Task.CompletedTask;

            List<string> userRoles = new List<string>();
            foreach (SocketRole role in ((SocketGuildUser)msg.Author).Roles)
                userRoles.Add(role.Name);

            foreach (ICommand command in CommandsList.Commands)
            {
                if (command.Config.Roles != null)
                {
                    var list = userRoles.Intersect(command.Config.Roles).ToArray();
                    if (list.Length == 0)
                        continue;
                }

                if (command.Config.Prefix == null || command.Config.Name == null)
                    continue;

                string pattern = $@"^{command.Config.Prefix}{command.Config.Name}\s*".ToLower();
                Regex commandFetcher = new Regex(pattern);
                if (!commandFetcher.IsMatch(msg.Content.ToLower()))
                    continue;

                bool skip = false;

                if (command.Config.ChannelIds == null)
                {
                    AddCommandInQueue(command.Config.Name, () => { command.FromChatHandler(this, msg); }, msg.Author);
                    return Task.CompletedTask;
                }

                foreach (var id in command.Config.ChannelIds)
                {
                    if (msg.Channel.Id == id)
                        break;

                    skip = true;
                }
                if (skip) continue;

                AddCommandInQueue(command.Config.Name, () => { command.FromChatHandler(this, msg); }, msg.Author);

                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
        private Task LogHandler(LogMessage msg)
        {
            Log?.Invoke(msg);
            return Task.CompletedTask;
        }
        #endregion
    }
}