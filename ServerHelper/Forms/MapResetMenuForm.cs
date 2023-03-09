using Newtonsoft.Json;
using ServerHelper.Core.MapResetTool;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Forms
{
    public partial class MapResetMenuForm : Form
    {
        private string PathToZonesFile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.DataFolder}\\ScheduledForReset.zones";
        private string PathResetCfgFile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.DataFolder}\\ScheduledForReset.json";

        public MapResetMenuForm()
        {
            InitializeComponent();

            Map.OnResetStarted += Map_OnResetStarted;
            Map.OnResetEnded += Map_OnResetEnded;
        }

        private void ShowMessageWhenMapNotLoaded()
        {
            MessageBox.Show("Для работы необходимо включить карту.",
                            "Включите карту",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        private void UpdateControls()
        {
            if (Map.IsReset)
            {
                foreach (var button in FormManager.GetAllControls(this, typeof(Button)).Where(b => b.Name != abort_btn.Name))
                    button.Invoke((Action)(() => { button.Enabled = false; }));

                foreach (var checkBox in FormManager.GetAllControls(this, typeof(CheckBox)))
                    checkBox.Invoke((Action)(() => { checkBox.Enabled = false; }));
            }
            else
            {
                foreach (var button in FormManager.GetAllControls(this, typeof(Button)))
                    button.Invoke((Action)(() => { button.Enabled = true; }));

                foreach (var checkBox in FormManager.GetAllControls(this, typeof(CheckBox)))
                    checkBox.Invoke((Action)(() => { checkBox.Enabled = true; }));
            }
        }
        private async void reset_btn_ClickAsync(object sender, EventArgs e)
        {
            if (Map.IsReset)
                return;

            MapResetForm mapResetForm = FormManager.Forms.Find(m => m.GetType() == typeof(MapResetForm)) as MapResetForm;

            if (mapResetForm.PZMap.Bmp == null)
            {
                ShowMessageWhenMapNotLoaded();
                return;
            }

            if (!Directory.Exists(Settings.Default.MapFolderPath))
            {
                MessageBox.Show("Указанная директория с сохранениями карты не существует.\r\n" +
                                "Проверьте настройки во вкладке \"Калибровка карты\"",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите начать сброс карты?\r\n\r\n",
                                            "Внимание",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            bool isAbort = await Map.ResetMapAsync(Settings.Default.MapFolderPath, mapResetForm.PZMap.Zones, bypassPrivates_cb.Checked, saveDeletedFiles_cb.Checked, reset_pb, currentCheckedFile_lbl);

            if (!isAbort)
            {
                currentCheckedFile_lbl.Invoke((Action)(() => { currentCheckedFile_lbl.Text = "Завершено"; }));
                MessageBox.Show("Сброс прошёл успешно. Обход файлов завершён. Если вы сохраняли резервную копию, то она доступна в папке Data программы.",
                                "Отчёт о сбросе",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
        private void abort_btn_Click(object sender, EventArgs e)
        {
            if (!Map.IsReset)
                return;

            var result = MessageBox.Show("Вы уверены, что хотите прервать сброс?\r\n\r\n",
                                    "Внимание",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            Map.AbortReset();

            MessageBox.Show("Сброс был прерван.",
                            "Сброс прерван",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        private void plan_btn_Click(object sender, EventArgs e)
        {
            try
            {
                MapResetForm mapResetForm = FormManager.Forms.Find(m => m.GetType() == typeof(MapResetForm)) as MapResetForm;
                if (mapResetForm.PZMap.Bmp == null)
                {
                    ShowMessageWhenMapNotLoaded();
                    return;
                }

                Settings.Default.IsResetMapDuringRestart = true;
                Settings.Default.PathResetCfgFile = PathResetCfgFile;
                Settings.Default.Save();

                MapZone.ZonesSerialize(mapResetForm.PZMap.Zones, PathToZonesFile, "All");

                MapResetConfig ResetConfig = new MapResetConfig()
                {
                    MapSaveFolder = Settings.Default.MapFolderPath,
                    PathToZonesFile = PathToZonesFile,
                    BypassPrivate = bypassPrivates_cb.Checked,
                    BackupFiles = saveDeletedFiles_cb.Checked,
                    ProgressBar = null,
                    CurrentFile = null,
                };
                using (FileStream fs = new FileStream(PathResetCfgFile, FileMode.Create))
                {
                    var json = JsonConvert.SerializeObject(ResetConfig, Formatting.Indented);
                    byte[] buffer = Encoding.Default.GetBytes(json);
                    fs.Write(buffer, 0, buffer.Length);
                }

                MessageBox.Show("Сброс карты с заданными параметрами и зонами запланирован на ближайший рестарт. Об этом говорит зелёный индикатор вверху приложения. Можете выгружать карту.",
                                "Планировщик сброса",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент создания конфига сброса произошла непредвиденная ошибка: {ex.Message}",
                "Планировщик сброса",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                Settings.Default.IsResetMapDuringRestart = false;
                Settings.Default.PathResetCfgFile = "default";
                Settings.Default.Save();
            }
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Settings.Default.IsResetMapDuringRestart = false;
            Settings.Default.PathResetCfgFile = "default";
            Settings.Default.Save();

            if (File.Exists(PathResetCfgFile))
                File.Delete(PathResetCfgFile);
            if (File.Exists(PathToZonesFile))
                File.Delete(PathToZonesFile);

            MessageBox.Show("Сброс карты отменён.",
                            "Планировщик сброса",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        private void MapResetMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Map.IsReset)
            {
                var result = MessageBox.Show("В текущий момент осуществляется сброс карты, при выходе сброс будет прерван, вы уверены?\r\n\r\n",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                Map.AbortReset();

                MessageBox.Show("Сброс был прерван.",
                                "Сброс прерван",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information); 
            }
            Map.OnResetStarted -= Map_OnResetStarted;
            Map.OnResetEnded -= Map_OnResetEnded;
        }
        private void Map_OnResetEnded()
        {
            UpdateControls();
        }
        private void Map_OnResetStarted()
        {
            UpdateControls();
        }
    }
}