using ServerHelper.Core;
using ServerHelper.Core.DiscordBot;
using ServerHelper.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ServerHelper
{
    public partial class MainForm : Form, IForm
    {
        public bool IsMinimize { get; private set; }
        public Form ActiveChieldForm { get; private set; }
        public Button CurrentButton { get; private set; }
        public Color CurrentColorTheme { get; private set; }

        private Random random;
        //private int tempIndex;

        private Size currentSize;
        private Size minimizeSize = new Size(215, 95);
        private Size minSize;
        private Size maxSize;

        private DiscordForm discordForm;
        private ServerHelperForm serverHelperForm;
        private MapResetForm mapResetForm;
        private SettingsForm settingsForm;

        public MainForm()
        {
            FormManager.RegisterForm(this);
            InitializeComponent();

            minSize = MinimumSize;
            maxSize = MaximumSize;

            Text = string.Empty;
            ControlBox = false;
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            random = new Random();
            backHome_btn.Visible = false;

            EverySecond.Enabled = true;
            EverySecond.Tick += UpdateControlsHandler;

            discordForm = new DiscordForm();
            serverHelperForm = new ServerHelperForm();
            mapResetForm = new MapResetForm();
            settingsForm = new SettingsForm();

            //Костыль для создания дескрипторов всех форм
            Button _ = new Button();
            OpenChildForm(discordForm, _);
            OpenChildForm(serverHelperForm, _);
            OpenChildForm(mapResetForm, _);
            OpenChildForm(settingsForm, _);
            if (ActiveChieldForm != null)
                ActiveChieldForm.Hide();
            Reset();

            if (Properties.Settings.Default.IsStartAppMinimize)
                Minimize();
        }

        #region DLLImport для Drag&Drop
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region Публичные методы
        public void Maximize()
        {
            if (IsMinimize)
            {
                IsMinimize = false;
                MinimumSize = minSize;
                MaximumSize = maxSize;
                Size = currentSize;
            }
        }
        public void Minimize()
        {
            if (!IsMinimize)
            {
                IsMinimize = true;
                currentSize = Size;

                MinimumSize = minimizeSize;
                MaximumSize = minimizeSize;
                Size = minimizeSize;
            }
        }
        public void OpenChildForm(Form childForm, object btnSender, Color color = default)
        {
            if(ActiveChieldForm == childForm)
                return;

            if (ActiveChieldForm != null)
                ActiveChieldForm.Hide();

            if(color == default)
                CurrentColorTheme = SelectThemeColor();
            titleBar_pnl.BackColor = CurrentColorTheme;

            ActivateButton(btnSender);
            ActiveChieldForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.desktopPanel_pnl.Controls.Add(childForm);
            this.desktopPanel_pnl.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Title_lbl.Text = childForm.Text;
        }
        public IForm GetForm()
        {
            return this;
        }
        #endregion

        #region Приватные методы (работа с формой)
        private Color SelectThemeColor()
        {
            //int index = random.Next(ThemeColor.ColorList.Count);
            //while (tempIndex == index)
            //{
            //    index = random.Next(ThemeColor.ColorList.Count);
            //}
            //tempIndex = index;
            string color = ThemeColor.ColorList[1];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (CurrentButton != (Button)btnSender)
                {
                    DisableButton();
                    CurrentButton = (Button)btnSender;
                    CurrentButton.ForeColor = Color.White;
                    CurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    CurrentButton.BackColor = CurrentColorTheme;
                    backHome_btn.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void Reset()
        {
            DisableButton();
            Title_lbl.Text = "Главная";
            titleBar_pnl.BackColor = Color.FromArgb(0, 150, 136);
            logoBar_pnl.BackColor = Color.FromArgb(39, 39, 58);
            CurrentButton = null;
            backHome_btn.Visible = false;
            ActiveChieldForm = null;
        }

        #endregion

        #region Обработчики кнопок (переключение вкладок)
        private void discord_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(discordForm, sender);
        }
        private void serverHelper_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(serverHelperForm, sender);
        }
        private void mapResetTool_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(mapResetForm, sender);
        }
        private void applicationSettings_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(settingsForm, sender);
        }
        #endregion

        #region Обработчики кнопок (закрыть\свернуть)
        private void backHome_btn_Click(object sender, EventArgs e)
        {
            if (ActiveChieldForm != null)
                ActiveChieldForm.Hide();
            Reset();
        }
        private void appMinimize_btn_Click(object sender, EventArgs e)
        {
            if (!IsMinimize)
                Minimize();
            else
                Maximize();
        }
        private void logoBar_btn_Click(object sender, EventArgs e)
        {
            if (!IsMinimize)
                Minimize();
            else
                Maximize();
        }
        private void appClose_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Ежесекундные обработчики элементов формы
        private void UpdateControlsHandler(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke((Action<object, EventArgs>)UpdateControlsHandler, sender, e);
            else
            {
                if (discordForm.DiscordBot.IsOnline)
                    botStatus_pb.Image = Properties.Resources.botOnline;
                else botStatus_pb.Image = Properties.Resources.botOffline;

                if (serverHelperForm.RconShell.IsConnect)
                    rconStatus_pb.Image = Properties.Resources.rconOnline;
                else rconStatus_pb.Image = Properties.Resources.rconOffline;

                if(Properties.Settings.Default.IsResetMapDuringRestart)
                    mapReset_pb.Image = Properties.Resources.resetMapOn;
                else mapReset_pb.Image = Properties.Resources.resetMapOff;

                utcTime_lbl.Text = String.Format("{0} UTC", DateTime.UtcNow.ToString(new CultureInfo("ru-RU")));
            }
        }
        #endregion

        #region Drag&Drop
        private void titleBar_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void logoBar_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void logoBar_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Title_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void utcTime_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
