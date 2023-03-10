using Discord;
using Discord.Net;
using Discord.WebSocket;
using ServerHelper.Forms;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class GSSGommand : ICommand
    {
        public CommandConfig Config { get; set; }

        private bool isHandling = false;

        private GSSGommand()
        {
        }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            if (isHandling)
                return;

            isHandling = true;
            try
            {
                var path = SaveGraph().Result;
                if (path == null)
                {
                    await bot.SendMessageAsync(msg.Channel.Id, "Не удалось обновить график т.к. форма с графиком закрыта");
                }
                else
                {
                    await RemoveAllMessagesAsync(bot, msg.Channel.Id);
                    await bot.SendFileAsync(msg.Channel.Id, path);
                }
            }
            catch (Exception) { throw; }
            finally { isHandling = false; }
        }
        public async Task FromCodeHandler(BotShell bot, object[] args)
        {
            if (isHandling)
                return;

            isHandling = true;

            try
            {
                ulong cannelid;

                if (args.Length == 0)
                    throw new ArgumentException("Не переданы аргументы, команда ожидала ulong ID канала в качестве первого аргумента.");
                try { cannelid = (ulong)args[0]; }
                catch (InvalidCastException ex)
                {
                    throw new InvalidCastException("Команда ожидала ulong ID канала в качестве первого аргумента: " + ex.Message);
                }

                var path = SaveGraph().Result;
                if (path == null)
                {
                    await RemoveAllMessagesAsync(bot, cannelid);
                    await bot.SendMessageAsync(cannelid, "Не удалось обновить график т.к. форма с графиком закрыта");
                }
                else
                {
                    await RemoveAllMessagesAsync(bot, cannelid);
                    await bot.SendFileAsync(cannelid, path);
                }
            }
            catch (Exception) { throw; }
            finally { isHandling = false; }
        }
        private async Task RemoveAllMessagesAsync(BotShell bot, ulong channelId)
        {
            try
            {
                var guild = bot.GetGuild();
                var channel = guild.TextChannels.Single(ch => ch.Id == channelId);
                var messages = channel.GetMessagesAsync().Flatten();

                foreach (var m in await messages.ToArrayAsync())
                {
                    await m.DeleteAsync();
                }
            }
            catch (HttpException) { }
            catch (Exception) { throw; }
        }
        private async Task<string> SaveGraph()
        {
            GSSChartBuilder gssChartBuilder = ModuleManager.Modules.Find(m => m.GetType() == typeof(GSSChartBuilder)) as GSSChartBuilder;
            GSSChartForm chartForm = (FormManager.Forms.Find(m => m.GetType() == typeof(DiscordForm)) as DiscordForm).ChartForm;

            if (gssChartBuilder == null || chartForm == null || chartForm.IsDisposed)
                return null;


            string path = null;
            bool isSave = false;
            while (!isSave)
            {
                try
                {
                    await gssChartBuilder.UpdateGraphAsync();

                    path = await gssChartBuilder.SaveImageAsync();
                    isSave = true;
                }
                catch (InvalidOperationException) { isSave = false; }
                catch (Exception) { throw; }
            }

            return path;
        }
    }
}