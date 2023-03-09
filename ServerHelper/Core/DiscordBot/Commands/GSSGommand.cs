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

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class GSSGommand : ICommand
    {
        public CommandConfig Config { get; set; }

        private bool isHandling = false;
        private bool appWasMinimize = false;
        private MainForm mainForm;
        private DiscordForm discordForm;
        private Form activeForm;
        private Button activeButton;

        private GSSGommand()
        {
            mainForm = FormManager.Forms.Find(m => m.GetType() == typeof(MainForm)) as MainForm;
            discordForm = FormManager.Forms.Find(m => m.GetType() == typeof(DiscordForm)) as DiscordForm;
        }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            if (isHandling)
                return;

            isHandling = true;
            try
            {
                await RemoveAllMessagesAsync(bot, msg.Channel.Id);
                await bot.SendFileAsync(msg.Channel.Id, SaveGraph().Result);
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

                await RemoveAllMessagesAsync(bot, cannelid);
                await bot.SendFileAsync(cannelid, SaveGraph().Result);
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
            GSSChartBuilder gssChartBuilder;
            gssChartBuilder = ModuleManager.Modules.Find(m => m.GetType() == typeof(GSSChartBuilder)) as GSSChartBuilder;

            string path = null;
            bool isSave = false;
            while (!isSave)
            {
                try
                {
                    await gssChartBuilder.UpdateGraphAsync();

                    FocusDiscodForm();
                    path = await gssChartBuilder.SaveImageAsync();
                    isSave = true;
                }
                catch (InvalidOperationException) { isSave = false; }
                catch (Exception) { throw; }
                finally { UnfocusDiscordForm(); }
            }

            return path;
        }
        private void FocusDiscodForm()
        {

            activeForm = mainForm.ActiveChieldForm;
            activeButton = mainForm.CurrentButton;
            mainForm.Invoke((Action)(() => { mainForm.Enabled = false; }));

            if (mainForm.IsMinimize)
                appWasMinimize = true;
            else appWasMinimize = false;

            if (mainForm.ActiveChieldForm.GetType() == typeof(DiscordForm) && !mainForm.IsMinimize)
                return;

            else
            {
                mainForm.Invoke((Action)(() =>
                {
                    mainForm.Maximize();
                    mainForm.OpenChildForm(discordForm, mainForm.Controls.Find("discord_btn", true)[0], mainForm.CurrentColorTheme);
                }));
            }
        }
        private void UnfocusDiscordForm()
        {
            mainForm.Invoke((Action)(() => { mainForm.Enabled = true; }));

            if (appWasMinimize)
                mainForm.Invoke((Action)(() => { mainForm.Minimize(); }));

            if (mainForm.ActiveChieldForm == activeForm)
                return;
            else
            {
                mainForm.Invoke((Action)(() => { mainForm.OpenChildForm(activeForm, activeButton); }));
            }
        }
    }
}