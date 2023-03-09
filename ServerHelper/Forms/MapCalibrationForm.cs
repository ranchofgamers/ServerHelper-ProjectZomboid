using ServerHelper.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Forms
{
    public partial class MapCalibrationForm : Form
    {
        public MapCalibrationForm()
        {
            InitializeComponent();
            InitSettings();
        }
        private void InitSettings()
        {
             refLTX_tb.Text = Properties.Settings.Default.RefLTX.ToString();
             refLTY_tb.Text = Properties.Settings.Default.RefLTY.ToString();

             refLBX_tb.Text = Properties.Settings.Default.RefLBX.ToString();
             refLBY_tb.Text = Properties.Settings.Default.RefLBY.ToString();

             refRTX_tb.Text = Properties.Settings.Default.RefRTX.ToString();
             refRTY_tb.Text = Properties.Settings.Default.RefRTY.ToString();

             refRBX_tb.Text = Properties.Settings.Default.RefRBX.ToString();
             refRBY_tb.Text = Properties.Settings.Default.RefRBY.ToString();

             mapFolderPath_tb.Text = Properties.Settings.Default.MapFolderPath;
             mapFilePath_tb.Text = Properties.Settings.Default.MapFilePath;
        }

        #region Обработчики кнопок
        private void saveSettings_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.RefLTX = Convert.ToSingle(refLTX_tb.Text);
                Properties.Settings.Default.RefLTY = Convert.ToSingle(refLTY_tb.Text);

                Properties.Settings.Default.RefLBX = Convert.ToSingle(refLBX_tb.Text);
                Properties.Settings.Default.RefLBY = Convert.ToSingle(refLBY_tb.Text);

                Properties.Settings.Default.RefRTX = Convert.ToSingle(refRTX_tb.Text);
                Properties.Settings.Default.RefRTY = Convert.ToSingle(refRTY_tb.Text);

                Properties.Settings.Default.RefRBX = Convert.ToSingle(refRBX_tb.Text);
                Properties.Settings.Default.RefRBY = Convert.ToSingle(refRBY_tb.Text);


                MapResetForm mapResetForm = FormManager.Forms.Find(m => m.GetType() == typeof(MapResetForm)) as MapResetForm;

                mapResetForm.PZMap.LT = new PointF(Properties.Settings.Default.RefLTX, Properties.Settings.Default.RefLTY);
                mapResetForm.PZMap.LB = new PointF(Properties.Settings.Default.RefLBX, Properties.Settings.Default.RefLBY);

                mapResetForm.PZMap.RT = new PointF(Properties.Settings.Default.RefRTX, Properties.Settings.Default.RefRTY);
                mapResetForm.PZMap.RB = new PointF(Properties.Settings.Default.RefRBX, Properties.Settings.Default.RefRBY);

                Properties.Settings.Default.MapFolderPath = mapFolderPath_tb.Text;
                Properties.Settings.Default.MapFilePath = mapFilePath_tb.Text;

                Properties.Settings.Default.Save();

                if (mapResetForm.PZMap.Bmp != null)
                {
                    if (Properties.Settings.Default.MapFilePath == "default")
                        mapResetForm.PZMap.LoadBitmap(new Bitmap(Properties.Resources.pzmap));
                    else
                        mapResetForm.PZMap.LoadBitmap(new Bitmap(SelectMapFilePath.FileName, false));

                    mapResetForm.PZMap.Zones.Clear();
                    mapResetForm.UpdateListView();
                    mapResetForm.PZMap.Draw();

                    MessageBox.Show($"Настройки успешно сохранены. Карта перезагружена.");
                }
                else
                {
                    MessageBox.Show($"Настройки успешно сохранены");
                }
            }
            catch (Exception ex) {MessageBox.Show($"При попытке сохранить настройки произошла ошибка: {ex.Message}");}
        }
        private void changeMapFile_btn_Click(object sender, EventArgs e)
        {
            if (SelectMapFilePath.ShowDialog() == DialogResult.Cancel)
                return;

            mapFilePath_tb.Text = SelectMapFilePath.FileName;
        }
        private void resertToDefaultMap_btn_Click(object sender, EventArgs e)
        {
            mapFilePath_tb.Text = "default";
        }
        private void changeMapFolderPath_btn_Click(object sender, EventArgs e)
        {
            if (ChoiceMapFolderPath.ShowDialog() == DialogResult.Cancel)
                return;

            mapFolderPath_tb.Text = ChoiceMapFolderPath.SelectedPath;
        }
        #endregion

        #region Обработчики ввода координат в TextBox
        private void CoordsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                var separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != separator)
                {
                    if (e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22 && e.KeyChar != 24)
                        e.Handled = true;
                }
            }
            else e.Handled = true;
        }
        #endregion

        #region Обработчики событий
        private void MapCalibrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = FormManager.Forms.Find(m => m.GetType() == typeof(MainForm)) as MainForm;
            mainForm.Enabled = true;

            MapResetForm mapResetForm = FormManager.Forms.Find(m => m.GetType() == typeof(MapResetForm)) as MapResetForm;
            mapResetForm.Enabled = true;

            mapResetForm.Focus();
        }
        #endregion
    }
}
