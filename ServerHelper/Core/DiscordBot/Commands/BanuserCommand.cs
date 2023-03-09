using Discord.WebSocket;
using Microsoft.VisualBasic.Devices;
using ServerHelper.Forms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class BanuserCommand : ICommand
    {
        public CommandConfig Config { get; set; }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            ServerHelperForm serverHelperForm;
            serverHelperForm = FormManager.Forms.Find(m => m.GetType() == typeof(ServerHelperForm)) as ServerHelperForm;

            DiscordForm discordForm;
            discordForm = FormManager.Forms.Find(m => m.GetType() == typeof(DiscordForm)) as DiscordForm;

            if (!discordForm.DiscordBot.IsOnline)
                return;

            if (!serverHelperForm.RconShell.IsConnect)
            {
                await msg.Channel.SendMessageAsync("ROCN не подключен, невозможно отправить команду.");
                return;
            }

            var args = Regex.Split(msg.Content, $@"^{Config.Prefix}{Config.Name}\s*", RegexOptions.IgnoreCase);
            var argsList = args.ToList();
            argsList.RemoveAll(x => x == string.Empty);

            if (argsList.Count == 0)
            {
                await msg.Channel.SendMessageAsync("Команда введена неверно, отсутствует имя пользователя");
                return;
            }
            else
            {
                var responce = await serverHelperForm.RconShell.SendCommandAsync($"banuser {argsList[0]} -ip -r \"Banned from Discord, Observer: {msg.Author.Username}\"");
                await msg.Channel.SendMessageAsync($"Сервер ответил: {responce}");
                return;
            }
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}