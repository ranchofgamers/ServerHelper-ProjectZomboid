using ServerHelper.Core;
using ServerHelper.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text;
using Ionic.Zip;
using ServerHelper.Core.MapResetTool;
using Newtonsoft.Json;

namespace ServerHelper.Forms
{
    public partial class ServerHelperForm : Form, IForm
    {
        public RconShell RconShell { get; private set; }
        public ServerProcessShell ServerProcessShell { get; private set; }
        public bool IsServerRestarting { get; private set; }
        public bool IsBackuping { get; private set; }
        public bool IsServerStopping { get; private set; }

        private TimeSpan timeToRestart;
        private DateTime currentDatToLog;

        public ServerHelperForm()
        {
            FormManager.RegisterForm(this);
            InitializeComponent();
            InitSettings();

            currentDatToLog = DateTime.UtcNow.Date;

            ServerProcessShell = new ServerProcessShell("Death Cycle", Settings.Default.ServerStartFilePath);
            ServerProcessShell.OnProcessStarted += ServerShell_OnProcessStarted;
            ServerProcessShell.OnProcessShutdown += ServerShell_OnProcessShutdown;

            RconShell = new RconShell();
            RconShell.OnConnected += RconShell_OnConnected;
            RconShell.OnDisconnected += RconShell_OnDisconnected;

            EverySecond.Tick += EverySecControlsUpdater;
            EverySecond.Tick += EverySecRestartServerChecker;
            EverySecond.Tick += UpdateLogTime;
            EverySecond.Start();

            EveryTenSeconds.Tick += EveryTenSecRconReconnecter;
            EveryTenSeconds.Tick += ServerAutoStartWithApp;
            EveryTenSeconds.Start();

            RestartMessageTimer.Tick += SendRestartMessages;
        }

        #region Публичные методы
        public IForm GetForm()
        {
            return this;
        }
        public void WriteMessageToLogTextBox(string msg)
        {
            if (InvokeRequired)
                Invoke((Action<string>)WriteMessageToLogTextBox, msg);
            else
            {
                string _msg = DateTime.UtcNow.ToString() + ": " + msg + Environment.NewLine;
                serverResponce_rtb.Text += _msg;

                if (serverResponce_rtb.Text.Length >= 3000)
                {
                    string source = serverResponce_rtb.Text;
                    source = source.Substring(1000);
                    serverResponce_rtb.Text = source;
                }

                serverResponce_rtb.SelectionStart = serverResponce_rtb.Text.Length;
                serverResponce_rtb.ScrollToCaret();
                WriteLogToFile(_msg);
            }
        }
        public async Task RestartServer()
        {
            await RestartGameServerAsync(false);
        }
        public async Task StopServer()
        {
            await StopGameServerAsync();
        }
        public void StartServer()
        {
            StartGameServer();
        }
        #endregion

        #region Приватные методы
        private void InitSettings()
        {
            serverIP_tb.Text = Settings.Default.ServerIP;
            rconPort_tb.Text = Settings.Default.RconPort.ToString();
            rconPassword_tb.Text = Settings.Default.RconPassword;
            isRconAutoRestart_cb.Checked = Settings.Default.IsRconAutoConnect;

            restartUtcTime_tb.Text = Settings.Default.RestartUtcTime;
            serverStartFilePath_tb.Text = Settings.Default.ServerStartFilePath;
            serverFolderPath_tb.Text = Settings.Default.ServerFolderPath;
            serverBackupFolderPath_tb.Text = Settings.Default.ServerBackupFolderPath;
            isServerAutoRestart_cb.Checked = Settings.Default.IsServerAutoRestart;
            isSendRestartMsg_cb.Checked = Settings.Default.IsSendRestartMsg;
            isMakeBackup_cb.Checked = Settings.Default.IsMakeBackup;
        }
        private async Task ConnectRconAsync()
        {
            try
            {
                await RconShell.ConnectAsync(IPAddress.Parse(serverIP_tb.Text), Convert.ToUInt16(rconPort_tb.Text), rconPassword_tb.Text);
            }
            catch (Exception ex) { WriteMessageToLogTextBox(ex.Message); }
        }
        private void DisconnectRcon()
        {
            try
            {
                RconShell.Disconnect();
            }
            catch (Exception ex) { WriteMessageToLogTextBox(ex.Message); }
        }
        private void UpdateRconControls()
        {
            if (RconShell.IsConnecting)
            {
                rconConnect_btn.Enabled = false;
                rconConnect_btn.Text = "Подключаюсь...";
                rconStatus_lbl.ForeColor = Color.Red;
                rconStatus_lbl.Text = "Статус RCON: Подключение...";
            }
            else if (RconShell.IsDisconnecting)
            {
                rconConnect_btn.Enabled = false;
                rconConnect_btn.Text = "Отключаюсь...";
                rconStatus_lbl.ForeColor = Color.Green;
                rconStatus_lbl.Text = "Статус RCON: Отключение...";
            }
            else if (RconShell.IsConnect)
            {
                rconConnect_btn.Enabled = true;
                rconConnect_btn.Text = "Отключить RCON";
                rconStatus_lbl.ForeColor = Color.Green;
                rconStatus_lbl.Text = "Статус RCON: online";
            }
            else if (!RconShell.IsConnect)
            {
                rconConnect_btn.Enabled = true;
                rconConnect_btn.Text = "Подключить RCON";
                rconStatus_lbl.ForeColor = Color.Red;
                rconStatus_lbl.Text = "Статус RCON: offline";
            }
        }
        private void StartGameServer()
        {
            try { ServerProcessShell.Start(); }
            catch (Exception ex) { WriteMessageToLogTextBox($"Не удалось запустить сервер: {ex.Message}"); }
        }
        private async Task<bool> StopGameServerAsync()
        {
            if (IsServerStopping)
            {
                WriteMessageToLogTextBox($"Не удалось остановить сервер: уже останавливается");
                return false;
            }

            IsServerStopping = true;
            try
            {
                WriteMessageToLogTextBox($"Отправлен запрос на остановку сервера");
                string respnose = await RconShell.SendCommandAsync("quit");
                return true;
            }
            catch (Exception ex) { WriteMessageToLogTextBox($"Не удалось остановить сервер: {ex.Message}"); return false; }
        }
        private async Task RestartGameServerAsync(bool forceRestart)
        {
            if (IsServerRestarting)
            {
                WriteMessageToLogTextBox($"Не удалось перезапустить сервер: уже перезапускается");
                return;
            }

            IsServerRestarting = true;

            Action restartAction = () =>
            {
                try
                {
                    if (Settings.Default.IsMakeBackup)
                    {
                        IsBackuping = true;
                        MakeBackup(Settings.Default.ServerFolderPath, Settings.Default.ServerBackupFolderPath);
                    }
                }
                catch (Exception ex) { WriteMessageToLogTextBox($"Произошла ошибка при создании бэкапа сервера: {ex.Message}"); }
                finally { IsBackuping = false; IsServerRestarting = false; }

                try
                {
                    if (!Map.IsReset && Settings.Default.IsResetMapDuringRestart)
                    {
                        MapResetConfig ResetConfig = null;
                        if (File.Exists(Settings.Default.PathResetCfgFile))
                        {
                            try
                            {
                                string json = File.ReadAllText(Settings.Default.PathResetCfgFile, Encoding.Default);
                                ResetConfig = JsonConvert.DeserializeObject<MapResetConfig>(json);
                            }
                            catch (Exception ex) { WriteMessageToLogTextBox($"Произошла ошибка десериализации конфига сброса: {ex.Message}"); ResetConfig = null; }

                            if (ResetConfig != null)
                            {
                                if (File.Exists(ResetConfig.PathToZonesFile) && Directory.Exists(ResetConfig.MapSaveFolder))
                                    Map.ResetMap(ResetConfig.MapSaveFolder, MapZone.ZonesDeserialize(ResetConfig.PathToZonesFile, "All"), ResetConfig.BypassPrivate, ResetConfig.BackupFiles);

                                if (File.Exists(Settings.Default.PathResetCfgFile))
                                    File.Delete(Settings.Default.PathResetCfgFile);
                                if (File.Exists(ResetConfig.PathToZonesFile))
                                    File.Delete(ResetConfig.PathToZonesFile);
                            }
                        }
                    }
                }
                catch (Exception ex) { WriteMessageToLogTextBox($"Произошла ошибка при сбросе карты: {ex.Message}"); }
                finally { Settings.Default.IsResetMapDuringRestart = false; Settings.Default.Save(); }

                StartGameServer();
            };

            try
            {
                if (forceRestart)
                {
                    ServerProcessShell.KillServerProcess();

                    while (ServerProcessShell.IsServerProcessStarted)
                        await Task.Delay(1000);

                    await Task.Run(restartAction);
                }
                else
                {
                    if (await StopGameServerAsync())
                    {
                        int counter = 0;
                        while (ServerProcessShell.IsServerProcessStarted && counter < 61)
                        {
                            await Task.Delay(1000);
                            counter++;
                        }
                        if (counter == 61)
                        {
                            await RestartGameServerAsync(true);
                            return;
                        }
                    }
                    else { throw new InvalidOperationException("Не удалось отправить команду quit, рестарт отменён"); }

                    await Task.Run(restartAction);
                }
            }
            catch (Exception ex) { WriteMessageToLogTextBox($"Не удалось перезапустить сервер: {ex.Message}"); IsServerRestarting = false; }
        }
        private void UpdateServerControls()
        {
            serverStart_btn.Invoke((Action)(() =>
            {
                if (IsBackuping)
                {
                    serverStart_btn.Enabled = false;
                    serverStart_btn.Text = "Бэкапинг...";
                }
                else if (Map.IsReset)
                {
                    serverStart_btn.Enabled = false;
                    serverStart_btn.Text = "Сброс карты...";
                }
                else if (IsServerRestarting)
                {
                    serverStart_btn.Enabled = false;
                    serverStart_btn.Text = "Перезапуск...";
                }
                else if (IsServerStopping)
                {
                    serverStart_btn.Enabled = false;
                    serverStart_btn.Text = "Остановка...";
                }
                else if (ServerProcessShell.IsServerProcessStarted)
                {
                    serverStart_btn.Enabled = true;
                    serverStart_btn.Text = "Остановить сервер";
                }
                else if (!ServerProcessShell.IsServerProcessStarted)
                {
                    serverStart_btn.Enabled = true;
                    serverStart_btn.Text = "Запустить сервер";
                }

            }));

            serverRestart_btn.Invoke((Action)(() =>
            {
                if (IsBackuping)
                {
                    serverRestart_btn.Enabled = false;
                    serverRestart_btn.Text = "Бэкапинг...";
                }
                else if (Map.IsReset)
                {
                    serverRestart_btn.Enabled = false;
                    serverRestart_btn.Text = "Сброс карты...";
                }
                else if (IsServerRestarting)
                {
                    serverRestart_btn.Enabled = false;
                    serverRestart_btn.Text = "Перезапуск...";
                }
                else if (IsServerStopping)
                {
                    serverRestart_btn.Enabled = false;
                    serverRestart_btn.Text = "Остановка...";
                }
                else if (ServerProcessShell.IsServerProcessStarted)
                {
                    serverRestart_btn.Enabled = true;
                    serverRestart_btn.Text = "Перезапустить сервер";
                }
                else if (!ServerProcessShell.IsServerProcessStarted)
                {
                    serverRestart_btn.Enabled = false;
                    serverRestart_btn.Text = "Перезапустить сервер";
                }
            }));
        }
        private void WriteLogToFile(string msg)
        {
            try
            {
                var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.LogsFolder}";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter($"{path}\\ServerHelperFormLog_{currentDatToLog.ToShortDateString()}.txt", true))
                {
                    sw.Write(msg);
                }
            }
            catch (Exception) { }
        }
        private void MakeBackup(string source, string destination)
        {
            WriteMessageToLogTextBox($"Начато создание резервной копии сервера.");
            string ext = ".zip";
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-sstt");
            string fileName = $"{destination}//backup_{date}{ext}";
            int counter = 0;

            while (File.Exists(fileName))
            {
                counter++;
                fileName = $"{destination}_{date}_{counter}{ext}";
            }
            using (ZipFile zip = new ZipFile(fileName))
            {
                zip.UseZip64WhenSaving = Zip64Option.Always;
                zip.CompressionMethod = CompressionMethod.None;

                zip.AddDirectory(source);
                zip.Save();
            }
            WriteMessageToLogTextBox($"Закончено создание резервной копии сервера: {fileName}");
        }
        #endregion

        #region Обработчики нажатия кнопок
        private async void rconConnect_btn_Click(object sender, EventArgs e)
        {
            if (!RconShell.IsConnect)
                await ConnectRconAsync();
            else DisconnectRcon();
        }
        private void saveRconSettings_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ServerIP = serverIP_tb.Text;
                Settings.Default.RconPort = Convert.ToUInt16(rconPort_tb.Text);
                Settings.Default.RconPassword = rconPassword_tb.Text;
                Settings.Default.IsRconAutoConnect = isRconAutoRestart_cb.Checked;

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
        private async void rconSendCommand_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string respnose = await RconShell.SendCommandAsync(rconSendCommand_tb.Text);
                rconSendCommand_tb.Clear();
                if (respnose != null)
                    WriteMessageToLogTextBox($"Сервер ответил: {respnose}");
            }
            catch (Exception ex) { WriteMessageToLogTextBox($"Ошибка отправки сообщения: {ex.Message}"); }
        }
        private void rconSendCommand_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                rconSendCommand_btn_Click(sender, e);
                e.Handled = true;
            }
        }
        private void saveRestartSettings_bt_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.RestartUtcTime = restartUtcTime_tb.Text;
                Settings.Default.IsServerAutoRestart = isServerAutoRestart_cb.Checked;
                Settings.Default.IsSendRestartMsg = isSendRestartMsg_cb.Checked;
                Settings.Default.IsMakeBackup = isMakeBackup_cb.Checked;
                Settings.Default.ServerStartFilePath = serverStartFilePath_tb.Text;
                Settings.Default.ServerFolderPath = serverFolderPath_tb.Text;
                Settings.Default.ServerBackupFolderPath = serverBackupFolderPath_tb.Text;
                Settings.Default.Save();

                ServerProcessShell.StartFilePath = Settings.Default.ServerStartFilePath;

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
        private void changeServerStartFilePath_btn_Click(object sender, EventArgs e)
        {
            if (ChoiceServerStartFilePath.ShowDialog() == DialogResult.Cancel)
                return;

            serverStartFilePath_tb.Text = ChoiceServerStartFilePath.FileName.ToString();
        }

        private void changeServerFolderPath_btn_Click(object sender, EventArgs e)
        {
            if (ChoiceServerFolderPath.ShowDialog() == DialogResult.Cancel)
                return;

            serverFolderPath_tb.Text = ChoiceServerFolderPath.SelectedPath;
        }
        private void changeServerBackupFolderPath_btn_Click(object sender, EventArgs e)
        {
            if (ChoiceServerBackupFolderPath.ShowDialog() == DialogResult.Cancel)
                return;

            serverBackupFolderPath_tb.Text = ChoiceServerBackupFolderPath.SelectedPath;
        }
        private async void serverStart_btn_Click(object sender, EventArgs e)
        {
            if (!ServerProcessShell.IsServerProcessStarted)
                StartGameServer();
            else if (!RconShell.IsConnect)
            {
                serverStart_btn.Enabled = false;
                var reuslt = MessageBox.Show(
                    "Невозможно безопасно остановить сервер без RCON, убить процесс мгновенно?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (reuslt == DialogResult.Yes)
                    ServerProcessShell.KillServerProcess();
            }
            else if (RconShell.IsConnect)
            {
                var reuslt = MessageBox.Show(
                    "Вы действительно желаете остановить сервер?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if(reuslt == DialogResult.Yes)
                    await StopGameServerAsync();
            }    

        }
        private async void serverRestart_btn_Click(object sender, EventArgs e)
        {
            if (IsServerRestarting)
            {
                MessageBox.Show("Сервер уже перезапускается");
            }
            else if (!ServerProcessShell.IsServerProcessStarted)
            {
                MessageBox.Show("Сервер не запущен");
            }
            else if (ServerProcessShell.IsServerProcessStarted && RconShell.IsConnect && !IsServerRestarting)
            {
                var reuslt = MessageBox.Show(
                    "Вы действительно желаете перезапустить сервер?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (reuslt == DialogResult.Yes)
                    await RestartGameServerAsync(false);
            }
            else if (!RconShell.IsConnect)
            {
                serverStart_btn.Enabled = false;
                var reuslt = MessageBox.Show(
                    "Невозможно безопасно перезапустить сервер без RCON, перезапустить принудительно?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (reuslt == DialogResult.Yes)
                    await RestartGameServerAsync(true);
            }
        }
        #endregion

        #region Обработчики RconShell (Connect/Disconnect)
        private void RconShell_OnConnected()
        {
            UpdateRconControls();
            WriteMessageToLogTextBox("Подключение прошло успешно");
        }
        private void RconShell_OnDisconnected()
        {
            UpdateRconControls();
            WriteMessageToLogTextBox("Отключение прошло успешно");
        }
        #endregion

        #region Обработчики ServerShell (Connect/Disconnect)
        private void ServerShell_OnProcessStarted()
        {
            UpdateServerControls();
        }
        private void ServerShell_OnProcessShutdown()
        {
            IsServerStopping = false;
            UpdateServerControls();
        }
        #endregion

        #region Ежесекунные обработчики
        private void EverySecControlsUpdater(object sender, EventArgs e)
        {
            UpdateRconControls();
            UpdateServerControls();
        }
        private async void EverySecRestartServerChecker(object sender, EventArgs e)
        {
            try
            {
                if (IsBackuping)
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Сервер занят созданием резервной копии...";
                    RestartMessageTimer.Stop();
                    return;
                }
                else if (Map.IsReset)
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Сервер сбрасывает карту...";
                    RestartMessageTimer.Stop();
                    return;
                }
                else if (IsServerRestarting)
                {
                    //TODO: Тестим этот else if
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Сервер перезапускается...";
                    RestartMessageTimer.Stop();
                    return;
                }
                else if(!ServerProcessShell.IsServerProcessStarted)
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Сервер не запущен";
                    RestartMessageTimer.Stop();
                    return;
                }
                else if(!Settings.Default.IsServerAutoRestart)
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Рестарт не запланирован";
                    RestartMessageTimer.Stop();
                    return;
                }
                else if(!RconShell.IsConnect)
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Автоматический рестарт невозможен без RCON";
                    RestartMessageTimer.Stop();
                    return;
                }

                TimeSpan restartTime;
                if (TimeSpan.TryParse(Settings.Default.RestartUtcTime, out restartTime))
                {
                    timeToRestart = restartTime - new TimeSpan(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second);

                    if (timeToRestart < TimeSpan.Zero)
                        timeToRestart = timeToRestart + TimeSpan.FromHours(24);

                    serverAutoRestart_lbl.ForeColor = Color.Green;
                    serverAutoRestart_lbl.Text = $"Следующий рестарт через: {timeToRestart.ToString(@"hh\:mm\:ss")}";

                    if (Settings.Default.IsSendRestartMsg)
                    {
                        if (timeToRestart <= TimeSpan.FromMinutes(11) && RestartMessageTimer.Enabled == false)
                            RestartMessageTimer.Start();

                        if (timeToRestart <= TimeSpan.FromSeconds(11))
                        {
                            await RestartGameServerAsync(false);
                            return;
                        }
                    }
                }
                else
                {
                    serverAutoRestart_lbl.ForeColor = Color.Red;
                    serverAutoRestart_lbl.Text = "Неверно введено время";
                }
            }
            catch (Exception ex)
            {
                WriteMessageToLogTextBox($"Произошла непредвиденная ошибка во время отслеживания рестарта: {ex.Message}");
                RestartMessageTimer.Stop();
            }
        }
        private void UpdateLogTime(object sender, EventArgs e)
        {
            if (DateTime.UtcNow.Date > currentDatToLog)
                currentDatToLog = DateTime.UtcNow.Date;
        }
        #endregion

        #region Обработчики каждые 10 секунд
        private async void EveryTenSecRconReconnecter(object sender, EventArgs e)
        {
            if (!Settings.Default.IsRconAutoConnect || RconShell.IsConnect || !ServerProcessShell.IsServerProcessStarted)
                return;

            WriteMessageToLogTextBox("Попытка автоматического подключения RCON");
            await ConnectRconAsync();
        }
        private void ServerAutoStartWithApp(object sender, EventArgs e)
        {
            EveryTenSeconds.Tick -= ServerAutoStartWithApp;
            if (Settings.Default.IsStartServerWithApp && !ServerProcessShell.IsServerProcessStarted)
                StartGameServer();
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
        private void IPTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
                {
                    if (e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22 && e.KeyChar != 24)
                        e.Handled = true;
                }
            }
            else e.Handled = true;
        }
        private void restartUtcTime_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ':')
                {
                    if (e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22 && e.KeyChar != 24)
                        e.Handled = true;
                }
            }
            else e.Handled = true;
        }
        private async void SendRestartMessages(object sender, EventArgs e)
        {
            if (!IsServerRestarting && RconShell.IsConnect)
            {
                var responce = await RconShell.SendCommandAsync($"servermsg \"The server will be restarted in {timeToRestart.Minutes} minutes\"");
                WriteMessageToLogTextBox($"Перезапуск сервера через {timeToRestart.Minutes} минут");
            }
            else RestartMessageTimer.Stop();
        }
        #endregion
    }
}