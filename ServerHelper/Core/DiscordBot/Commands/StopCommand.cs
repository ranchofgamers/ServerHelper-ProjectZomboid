using Discord.WebSocket;
using Microsoft.VisualBasic.Devices;
using ServerHelper.Core.MapResetTool;
using ServerHelper.Forms;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class StopCommand : ICommand
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

            if (serverHelperForm.IsBackuping)
            {
                await msg.Channel.SendMessageAsync("Сервер занят созданием резервной копии.");
                return;
            }
            else if (Map.IsReset)
            {
                await msg.Channel.SendMessageAsync("Сервер занят сбросом карты.");
                return;
            }
            else if (serverHelperForm.IsServerRestarting)
            {
                await msg.Channel.SendMessageAsync("Сервер перезапускается.");
                return;
            }
            else if (!serverHelperForm.ServerProcessShell.IsServerProcessStarted)
            {
                await msg.Channel.SendMessageAsync("Сервер не запущен.");
                return;
            }
            else if (!serverHelperForm.RconShell.IsConnect)
            {
                await msg.Channel.SendMessageAsync("RCON отключен, безопасная остановка сервера через бота невозможна. Возможен только Abort.");
                return;
            }
            else
            {
                await msg.Channel.SendMessageAsync("Отправил команду на остановку.");
                await serverHelperForm.StopServer();
                return;
            }
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
