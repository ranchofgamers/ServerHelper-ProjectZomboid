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
    public class StatusCommand : ICommand
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
                await msg.Channel.SendMessageAsync(
                    "Процесс сервера запущен, но RCON отключен. Возможные причины:\r\n" +
                    "- Сервер запускается;\r\n" +
                    "- Возникла непредвиденная ошибка;\r\n" +
                    "\r\n" +
                    "Рекомендации:\r\n" +
                    "- Подождать запуска сервера;\r\n" +
                    "- Если текущее состояние сервера сохраняется более 10-20 минут, а сервер так и не доступен для входящих соедниений, обратитесь к **admin** или **наблюдатель**. **Наблюдатели** могут принудительно перезапустить сервер через **!abort** и **!start**;"
                    );
                return;
            }

            var responce = await serverHelperForm.RconShell.SendCommandAsync("players");

            string message =
            $"```\r\n" +
            $"{responce}" +
            $"```";

            await msg.Channel.SendMessageAsync(message);
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
