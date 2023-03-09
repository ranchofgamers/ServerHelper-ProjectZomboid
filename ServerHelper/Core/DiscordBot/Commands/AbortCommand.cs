using Discord.WebSocket;
using Microsoft.VisualBasic.Devices;
using ServerHelper.Forms;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class AbortCommand : ICommand
    {
        public CommandConfig Config { get; set; }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {

            DiscordForm discordForm;
            discordForm = FormManager.Forms.Find(m => m.GetType() == typeof(DiscordForm)) as DiscordForm;

            ServerHelperForm serverHelperForm;
            serverHelperForm = FormManager.Forms.Find(m => m.GetType() == typeof(ServerHelperForm)) as ServerHelperForm;

            if (!discordForm.DiscordBot.IsOnline)
                return;

            if (!serverHelperForm.ServerProcessShell.IsServerProcessStarted)
            {
                await msg.Channel.SendMessageAsync("Сервер не запущен.");
                return;
            }
            else
            {
                await msg.Channel.SendMessageAsync("Отправил команду на убийство процесса сервера.");
                serverHelperForm.ServerProcessShell.KillServerProcess();
                return;
            }
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
