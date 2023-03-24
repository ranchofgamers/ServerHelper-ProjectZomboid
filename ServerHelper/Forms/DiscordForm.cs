using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Serialization;
using ServerHelper.Properties;
using ServerHelper.Core;
using Discord;
using System.Reflection;
using ServerHelper.Core.DiscordBot;
using ServerHelper.Core.DiscordBot.Commands;
using Discord.WebSocket;
using System.Threading;

namespace ServerHelper.Forms
{
    public partial class DiscordForm : Form, IForm
    {
        public BotShell DiscordBot { get; private set; }
        public GSSChartForm ChartForm { get; private set; }

        private DateTime currentDatToLog;
        public DiscordForm()
        {
            FormManager.RegisterForm(this);
            InitializeComponent();
            InitSettings();

            currentDatToLog = DateTime.UtcNow.Date;

            DiscordBot = new BotShell(Settings.Default.DiscordBotToken, Settings.Default.DiscordServerId, "Main");
            DiscordBot.Log += DiscordBot_Log; ;
            DiscordBot.Connected += DiscordBot_Connected; ;
            DiscordBot.Disconnected += DiscordBot_Disconnected;

            EverySecond.Tick += RedrawGSSChartAsync;
            EverySecond.Tick += ChartAutoSendСhecker;
            EverySecond.Tick += UpdateLogTime;
            EverySecond.Start();

            TenSecondsAfterStartApp.Tick += BotAutoStartWithApp;
            TenSecondsAfterStartApp.Start();
        }

        #region Публичные методы
        public void WriteMessageToLogTextBox(string msg)
        {
            if (InvokeRequired)
                Invoke((Action<string>)WriteMessageToLogTextBox, msg);
            else
            {
                string _msg = DateTime.UtcNow.ToString() + ": " + msg + Environment.NewLine;
                botLog_rtb.Text += _msg;

                if (botLog_rtb.Text.Length >= 3000)
                {
                    string source = botLog_rtb.Text;
                    source = source.Substring(1000);
                    botLog_rtb.Text = source;
                }

                botLog_rtb.SelectionStart = botLog_rtb.Text.Length;
                botLog_rtb.ScrollToCaret();
                WriteLogToFile(_msg);
            }
        }
        public IForm GetForm()
        {
            return this;
        }
        #endregion

        #region Приватные методы
        private void InitSettings()
        {
            chartSourcePath_tb.Text = Settings.Default.GSSSourceFilePath.ToString();
            botToken_tb.Text = Settings.Default.DiscordBotToken;
            sendImageServerId_tb.Text = Settings.Default.DiscordServerId.ToString();
            sendChartChannelId_tb.Text = Settings.Default.SendChartChannelId.ToString();
            sendChartInterval_tb.Text = Settings.Default.SendChartInterval.ToString();
            isSendChart_cb.Checked = Settings.Default.IsSendChart;
            isBotAutoRestart_cb.Checked = Settings.Default.IsBotAutoRestart;
        }
        private async Task SwitchBotState()
        {
            try
            {
                EverySecond.Tick -= BotAutoReconnect;
                EverySecond.Tick += BotAutoReconnect;

                if (!DiscordBot.IsOnline && !DiscordBot.IsConnecting && !DiscordBot.IsDisconnecting)
                {
                    DiscordBot.UpdateInfo(Settings.Default.DiscordBotToken, Settings.Default.DiscordServerId, "Main");
                    await DiscordBot.RunAsync();
                    UpdateControls();
                }
                else if (DiscordBot.IsOnline && !DiscordBot.IsConnecting && !DiscordBot.IsDisconnecting)
                {
                    await DiscordBot.StopAsync();
                    UpdateControls();
                }
                else
                {
                    await DiscordBot.ResetStateAsync();
                    UpdateControls();
                }
            }
            catch (Exception ex)
            {
                WriteMessageToLogTextBox($"Во время изменения состояния бота возникло исключение. Состояние сброшено. Текст исключения: {ex.Message}");
                await DiscordBot.ResetStateAsync();
                UpdateControls();
            }
        }
        private void WriteLogToFile(string msg)
        {
            try
            {
                var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.LogsFolder}";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter($"{path}\\DiscordFormLog_{currentDatToLog.ToShortDateString()}.txt", true))
                {
                    sw.Write(msg);
                }
            }
            catch (Exception) { throw; }
        }
        private void ShowMessageWhenChartNotOpen()
        {
            MessageBox.Show("Для работы необходимо открыть форму с графиком.",
                            "Откройте форму с графиком",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        private void ShowMessageWhenDiscordBotDisconnected()
        {
            MessageBox.Show("Дискорд бот не подключен",
                            "Подключите дискорд бота",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        #endregion

        #region Обработчики нажатия кнопок
        private void changeSourcePath_btn_Click(object sender, EventArgs e)
        {
            if (ChoiceSourceFile.ShowDialog() == DialogResult.Cancel)
                return;

            chartSourcePath_tb.Text = ChoiceSourceFile.FileName.ToString();
        }
        private void sendExecuteChart_btn_Click(object sender, EventArgs e)
        {
            if (!DiscordBot.IsOnline)
            {
                ShowMessageWhenDiscordBotDisconnected();
                return;
            }

            if (ChartForm == null || ChartForm.IsDisposed)
            {
                ShowMessageWhenChartNotOpen();
                return;
            }

            object[] args = new object[1] { Settings.Default.SendChartChannelId };
            DiscordBot.AddCommandInQueue("GSS", args, sender);

        }
        private void addGSS_btn_Click(object sender, EventArgs e)
        {
            if (ChartForm == null || ChartForm.IsDisposed)
            {
                ShowMessageWhenChartNotOpen();
                return;
            }

            ChartForm.AddGSS(addGSS_tb.Text);
            addGSS_tb.Clear();
        }
        private void removeGSS_btn_Click(object sender, EventArgs e)
        {
            if (ChartForm == null || ChartForm.IsDisposed)
            {
                ShowMessageWhenChartNotOpen();
                return;
            }

            ChartForm.RemoveGSS(removeGSS_tb.Text);
            removeGSS_tb.Clear();
        }
        private void saveSettings_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.GSSSourceFilePath = chartSourcePath_tb.Text;
                Settings.Default.DiscordBotToken = botToken_tb.Text;
                Settings.Default.DiscordServerId = Convert.ToUInt64(sendImageServerId_tb.Text);
                Settings.Default.SendChartChannelId = Convert.ToUInt64(sendChartChannelId_tb.Text);
                Settings.Default.SendChartInterval = Convert.ToInt32(sendChartInterval_tb.Text);
                Settings.Default.IsSendChart = isSendChart_cb.Checked;
                Settings.Default.IsBotAutoRestart = isBotAutoRestart_cb.Checked;

                SendChartTimer.Interval = 60000 * Settings.Default.SendChartInterval;

                if (ChartForm != null && !ChartForm.IsDisposed)
                {
                    bool updateChart = false;
                    while (!updateChart)
                    {
                        try
                        {
                            ChartForm.GSSChart.UpdateInfo(null, Settings.Default.GSSSourceFilePath, null);
                            updateChart = true;
                        }
                        catch (InvalidOperationException) { updateChart = false; }
                    }
                }

                Settings.Default.Save();

                MessageBox.Show("Сохранено успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при попытке сохранения данных: " + ex.Message,
                                "Ошибка сохраненя данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private async void botConnect_btn_Click(object sender, EventArgs e)
        {
            await SwitchBotState();
        }
        private void openGSSChartForm_btn_Click(object sender, EventArgs e)
        {
            if(ChartForm == null || ChartForm.IsDisposed)
                ChartForm = new GSSChartForm();

            ChartForm.Show();
        }
        #endregion

        #region Обработчики событий (бота)
        private void DiscordBot_Connected()
        {
            UpdateControls();
        }
        private void DiscordBot_Disconnected(Exception ex)
        {
            UpdateControls();
        }
        private void DiscordBot_Log(LogMessage msg)
        {
            if (msg.Exception != null && msg.Exception.GetType() == typeof(CommandsHandlingException))
            {
                var exeption = (CommandsHandlingException)msg.Exception;
                foreach (var command in exeption.UnfulfilledCommands)
                {
                    var message = $"{msg.Source}: Комманда {command.Key.Name} не была обработа в связи с исключением: {command.Value.Message}";
                    WriteMessageToLogTextBox(message);
                }  
            }
            else if(msg.Exception != null)
                WriteMessageToLogTextBox($"{msg.Source}: {msg.Message} : {msg.Exception.Message}");
            else 
                WriteMessageToLogTextBox($"{msg.Source}: {msg.Message}");
        }
        #endregion

        #region Обработчики событий
        private async void BotAutoStartWithApp(object sender, EventArgs e)
        {
            TenSecondsAfterStartApp.Tick -= BotAutoStartWithApp;
            TenSecondsAfterStartApp.Stop();
            if (Settings.Default.IsStartBotWithApp && !DiscordBot.IsOnline && !DiscordBot.IsConnecting && !DiscordBot.IsDisconnecting)
                await SwitchBotState();
        }
        private async void BotAutoReconnect(object sender, EventArgs e)
        {
            if (Settings.Default.IsBotAutoRestart && !DiscordBot.IsOnline && !DiscordBot.IsConnecting && !DiscordBot.IsDisconnecting)
                await SwitchBotState();
        }
        private void ChartAutoSend(object sender, EventArgs e)
        {
            object[] args = new object[1] { Settings.Default.SendChartChannelId };
            DiscordBot.AddCommandInQueue("GSS", args, sender);
        }
        private void UpdateControls()
        {
            if (InvokeRequired)
                Invoke((Action)UpdateControls);
            else
            {
                if (!DiscordBot.IsOnline && !DiscordBot.IsDisconnecting && DiscordBot.IsConnecting)
                {
                    foreach (var button in FormManager.GetAllControls(this, typeof(Button)))
                        button.Enabled = false;

                    botConnect_btn.Text = "Подключение...";
                    botStatus_lbl.ForeColor = System.Drawing.Color.Red;
                    botStatus_lbl.Text = "Статус Bot'а: Подключение...";
                }
                else if (DiscordBot.IsOnline && DiscordBot.IsDisconnecting && !DiscordBot.IsConnecting)
                {
                    foreach (var button in FormManager.GetAllControls(this, typeof(Button)))
                        button.Enabled = false;

                    botConnect_btn.Text = "Отключение...";
                    botStatus_lbl.ForeColor = System.Drawing.Color.Red;
                    botStatus_lbl.Text = "Статус Bot'а: Отключение...";
                }
                else if (DiscordBot.IsOnline && !DiscordBot.IsDisconnecting && !DiscordBot.IsConnecting)
                {
                    foreach (var button in FormManager.GetAllControls(this, typeof(Button)))
                        button.Enabled = true;

                    botConnect_btn.Text = "Отключить";
                    botStatus_lbl.ForeColor = System.Drawing.Color.Green;
                    botStatus_lbl.Text = "Статус Bot'а: Online";
                }
                else if (!DiscordBot.IsOnline && !DiscordBot.IsDisconnecting && !DiscordBot.IsConnecting)
                {
                    foreach (var button in FormManager.GetAllControls(this, typeof(Button)))
                        button.Enabled = true;

                    botConnect_btn.Text = "Подключить";
                    botStatus_lbl.ForeColor = System.Drawing.Color.Red;
                    botStatus_lbl.Text = "Статус Bot'а: Offline";
                }
            }
        }
        #endregion

        #region Ежесекундные обработчики событий
        private async void RedrawGSSChartAsync(object sender, EventArgs e)
        {
            if (ChartForm != null && !ChartForm.IsDisposed && !ChartForm.GSSChart.IsUpdating)
                await ChartForm.GSSChart.UpdateGraphAsync();
        }
        private void ChartAutoSendСhecker(object sender, EventArgs e)
        {
            if (DiscordBot.IsOnline && !DiscordBot.IsConnecting && !DiscordBot.IsDisconnecting && Settings.Default.IsSendChart&& Settings.Default.SendChartInterval != 0)
            {
                if (SendChartTimer.Enabled == false)
                {
                    SendChartTimer.Tick += ChartAutoSend;
                    SendChartTimer.Interval = 60000 * Settings.Default.SendChartInterval;
                    SendChartTimer.Start();
                }
            }
            else if (SendChartTimer.Enabled == true)
            {
                SendChartTimer.Tick -= ChartAutoSend;
                SendChartTimer.Stop();
            }
        }
        private void UpdateLogTime(object sender, EventArgs e)
        {
            if (DateTime.UtcNow.Date > currentDatToLog)
                currentDatToLog = DateTime.UtcNow.Date;
        }
        #endregion

        #region Специфические обработчики
        private void DigitTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    if (e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22 && e.KeyChar != 24)
                        e.Handled = true;
                }
            }
            else e.Handled = true;
        }
        #endregion
    }
}
