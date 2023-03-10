using Microsoft.Win32;
using ServerHelper.Properties;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ServerHelper.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            InitSettings();
        }

        private void InitSettings()
        {
            isStartAppWithWindows_cb.Checked = Settings.Default.IsStartAppWithWindows;
            isStartServerWithApp_cb.Checked = Settings.Default.IsStartServerWithApp;
            isStartAppMinimize_cb.Checked = Settings.Default.IsStartAppMinimize;
            isStartBotWithApp_cb.Checked = Settings.Default.IsStartBotWithApp;
        }
        private void SetAutoRun(bool autorun)
        {
            string name = Application.ProductName;
            RegistryKey reg;
            try
            {
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

                if (autorun)
                {
                    if (reg.GetValue(name) == null)
                        reg.SetValue(name, Assembly.GetExecutingAssembly().Location);
                }
                else
                {
                    if (reg.GetValue(name) != null)
                        reg.DeleteValue(name);
                }

                reg.Flush();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void saveAppSettings_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.IsStartAppWithWindows = isStartAppWithWindows_cb.Checked;
                Settings.Default.IsStartServerWithApp = isStartServerWithApp_cb.Checked;
                Settings.Default.IsStartAppMinimize = isStartAppMinimize_cb.Checked;
                Settings.Default.IsStartBotWithApp = isStartBotWithApp_cb.Checked;

                Settings.Default.Save();


                if (Settings.Default.IsStartAppWithWindows)
                    SetAutoRun(true);
                else SetAutoRun(false);

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

    }
}
