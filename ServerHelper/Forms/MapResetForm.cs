using ServerHelper.Core;
using ServerHelper.Core.MapResetTool;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ServerHelper.Forms
{
    public partial class MapResetForm : Form, IForm
    {
        public Map PZMap { get; private set; }

        private MapCoordinates selectStartPoint;
        private MapCoordinates selectEndPoint;
        private MapZone selectRect;

        private MouseButtons currentMouseBtnPressed;
        
        public MapResetForm()
        {
            InitializeComponent();

            PZMap = new Map(PZMap_pb);

            PZMap.OnBitmapLoad += UpdateControls;
            PZMap.OnBitmapUnload += UpdateControls;

            PZMap.LT = new PointF(Properties.Settings.Default.RefLTX, Properties.Settings.Default.RefLTY);
            PZMap.LB = new PointF(Properties.Settings.Default.RefLBX, Properties.Settings.Default.RefLBY);

            PZMap.RT = new PointF(Properties.Settings.Default.RefRTX, Properties.Settings.Default.RefRTY);
            PZMap.RB = new PointF(Properties.Settings.Default.RefRBX, Properties.Settings.Default.RefRBY);

            PZMap_pb.MouseWheel += Map_pb_MouseWheel;
            PZMap_pb.Image = new Bitmap(PZMap_pb.Width, PZMap_pb.Height);
  
            selectTypeAddZone_cb.Items.AddRange(Enum.GetNames(typeof(MapZoneType)));
            selectTypeAddZone_cb.SelectedIndex = 0;

            selectDrawTypeZone_cb.Items.AddRange(Enum.GetNames(typeof(MapZoneType)));
            selectDrawTypeZone_cb.SelectedIndex = 0;

            selectTypeImpExpZone_cb.Items.Add("All");
            selectTypeImpExpZone_cb.Items.AddRange(Enum.GetNames(typeof(MapZoneType)));
            selectTypeImpExpZone_cb.SelectedIndex = 0;

            FormManager.RegisterForm(this);
        }

        #region Публичные методы
        public void UpdateListView()
        {
            zones_lv.Items.Clear();

            foreach (var zone in PZMap.Zones)
            {
                ListViewItem item = new ListViewItem(PZMap.Zones.IndexOf(zone).ToString());

                string type = "NAN";
                switch (zone.Type)
                {
                    case MapZoneType.Reset:
                        type = "RST";
                        break;
                    case MapZoneType.Claim:
                        type = "CLM";
                        break;
                    case MapZoneType.NoZombiesTerritory:
                        type = "NZT";
                        break;
                    case MapZoneType.ProhibitionOfDestruction:
                        type = "POD";
                        break;
                    default:
                        break;
                }

                item.SubItems.Add(type);
                item.SubItems.Add($"{Math.Round(zone.LeftTopPoint.GameWorldCoords.X,2)} x {Math.Round(zone.LeftTopPoint.GameWorldCoords.Y,2)}");
                item.SubItems.Add($"{Math.Round(zone.RightBotPoint.GameWorldCoords.X,2)} x {Math.Round(zone.RightBotPoint.GameWorldCoords.Y,2)}");

                item.Tag = zone;
                zone.CurrentBrush = zone.DefaultBrush;
                zones_lv.Items.Add(item);
            }
        }
        public IForm GetForm()
        {
            return this;
        }
        #endregion

        #region Приватные методы
        private void UpdateControls()
        {
            if (PZMap.Bmp == null)
            {
                mapStatus_lbl.Text = "Карта отключена. Ресурсы не заняты.";
                mapStatus_lbl.ForeColor = Color.Green;

                loadMap_btn.Text = "Включить карту";
                loadMap_btn.Enabled = true;
            }
            else
            {
                mapStatus_lbl.Text = "Карта загружена. Ресурсы выделены.";
                mapStatus_lbl.ForeColor = Color.Red;

                loadMap_btn.Text = "Выключить карту";
                loadMap_btn.Enabled = true;
            }
        }
        private void LablesInfoUpdate()
        {
            mapX_lbl.Text = $"X Coord: {PZMap.PointerCoordinates.GameWorldCoords.X}";
            mapY_lbl.Text = $"Y Coord: {PZMap.PointerCoordinates.GameWorldCoords.Y}";
            scale_lbl.Text = $"Scale: x{Math.Round(PZMap.Scl, 2)}";
        }
        private void ExportZones()
        {
            MapZone.ZonesSerialize(PZMap.Zones, ChoiceExportZonesFilePath.FileName, selectTypeImpExpZone_cb.Text);
        }
        private void ImportZones(bool addToExisting)
        {
            if (!addToExisting)
                PZMap.Zones.Clear();

            List<DeserializeZoneReport> deserializeReport = new List<DeserializeZoneReport>();

            var zones = MapZone.ZonesDeserialize(ChoiceImportZonesFilePath.FileName, selectTypeImpExpZone_cb.Text, deserializeReport);

            int skippedExistedZones = 0;
            foreach (var zone in zones)
            {
                zone.SetMapToPoints(PZMap);

                if (PZMap.Zones.Where(z =>
                    z.Type == zone.Type &&
                    z.LeftTopPoint.GameWorldCoords.X == zone.LeftTopPoint.GameWorldCoords.X &&
                    z.LeftTopPoint.GameWorldCoords.Y == zone.LeftTopPoint.GameWorldCoords.Y &&
                    z.RightBotPoint.GameWorldCoords.X == zone.RightBotPoint.GameWorldCoords.X &&
                    z.RightBotPoint.GameWorldCoords.Y == zone.RightBotPoint.GameWorldCoords.Y).Count() == 0)
                {
                    PZMap.Zones.Add(zone);
                    continue;
                }
                else skippedExistedZones++;
            }

            UpdateListView();
            PZMap.Draw();

            ShowImportMessageReport(deserializeReport, skippedExistedZones);
        }
        private void ShowImportMessageReport(List<DeserializeZoneReport> deserializeReport, int skippedExistedZones)
        {
            if (deserializeReport == null)
                return;

            int error = deserializeReport.Where(e => e.Type == DeserializeType.Error).Count();
            int skipped = deserializeReport.Where(e => e.Type == DeserializeType.Skipped).Count();

            string msg = $"При импорте обнаружено {deserializeReport.Count} зон.\r\n\r\n" +
                    $"Зон успешно импортировано: {deserializeReport.Count - error - skipped - skippedExistedZones}\r\n" +
                    $"Зон пропущено т.к. уже имеются на карте: {skippedExistedZones}\r\n" +
                    $"Зон пропущено при десериализации: {skipped}\r\n" +
                    $"Обнаружено ошибок при десериализации: {error}\r\n\r\n" +
                    $"Отчёт об импорте находится в папке: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.LogsFolder}";

            MessageBox.Show(msg, "Отчёт об импорте", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (deserializeReport.Count == 0)
                return;

            WriteDeserializeLog(deserializeReport);
        }
        private void WriteDeserializeLog(List<DeserializeZoneReport> report)
        {
            try
            {
                string message = "";
                foreach (var rep in report)
                {
                    if (rep.Type == DeserializeType.Successfully)
                        message += $"Зона с ID: {rep.ID} десериализована успешно\r\n";
                    else if (rep.Type == DeserializeType.Skipped)
                        message += $"Зона с ID: {rep.ID} пропущена т.к. тип зоны не соотвествовал целевому типу десериализации\r\n";
                    else if (rep.Type == DeserializeType.Error)
                        message += $"Зону с ID: {rep.ID} не удалось десериализовать. Возникло исключение: {rep.Message}\r\n";
                }

                var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.LogsFolder}";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter($"{path}\\ZonesImportLog_{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-sstt")}.txt", true))
                    sw.Write(message);
            }
            catch (Exception) { }
        }
        private void ShowMessageWhenMapNotLoaded()
        {
            MessageBox.Show("Для работы необходимо включить карту.",
                            "Включите карту",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        #endregion

        #region Обработчики формы
        private void MapResetForm_Resize(object sender, EventArgs e)
        {
            if (PZMap_pb.Width == 0 || PZMap_pb.Height == 0)
                return;

            PZMap_pb.Image = new Bitmap(PZMap_pb.Width, PZMap_pb.Height);

            if (PZMap.Bmp != null)
            {
                PZMap.Draw();
            }
        }
        #endregion

        #region Обработчики поведения мышки на PB
        private void Map_pb_MouseDown(object sender, MouseEventArgs e)
        {
            currentMouseBtnPressed = e.Button;

            if (PZMap.Bmp == null)
                return;

            if (currentMouseBtnPressed == MouseButtons.Right)
            {
                selectStartPoint = new MapCoordinates(PZMap);
                selectStartPoint.ViewCoords = new PointF(e.X, e.Y);
            }
            else if (currentMouseBtnPressed == MouseButtons.Left)
            {
                PZMap.PointerDown(e.X, e.Y);
            }
        }
        private void Map_pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (PZMap.Bmp == null)
                return;

            if (currentMouseBtnPressed == MouseButtons.Right && selectRect != null)
            {
                PZMap.Zones.Add(selectRect);
                UpdateListView();

                selectStartPoint = null;
                selectEndPoint = null;
                selectRect = null;
            }
            else if (currentMouseBtnPressed == MouseButtons.Left)
            {
                PZMap.ResetPointer();
            }

            currentMouseBtnPressed = MouseButtons.None;
            PZMap.Draw();
        }
        private void Map_pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (PZMap.Bmp == null)
                return;

            if (currentMouseBtnPressed == MouseButtons.Right && selectStartPoint != null)
            {
                if (selectEndPoint == null)
                    selectEndPoint = new MapCoordinates(PZMap);

                selectEndPoint.ViewCoords = new PointF(e.X, e.Y);

                if (selectRect == null)
                {
                    selectRect = new MapZone((MapZoneType)selectDrawTypeZone_cb.SelectedIndex);
                    selectRect.SetPointsViaView(selectStartPoint, selectEndPoint, PZMap);                 
                }
                else selectRect.SetPointsViaView(selectStartPoint, selectEndPoint, PZMap);

                PZMap.DrawSelectRect(selectRect);
                return;
            }
            else if (currentMouseBtnPressed == MouseButtons.Left)
            {
                if (PZMap.XD >= 0 && PZMap.YD >= 0)
                {
                    PZMap.MapMove(e.X, e.Y);
                }
            }

            PZMap.PointerCoordinates.ViewCoords = new PointF(e.X, e.Y);
            LablesInfoUpdate();
        }
        private void Map_pb_MouseWheel(object sender, MouseEventArgs e)
        {
            if (PZMap.Bmp == null)
                return;

            if (currentMouseBtnPressed != MouseButtons.None)
                return;

            PZMap.MapScale(e.X, e.Y, e.Delta);
        }
        #endregion

        #region Обработчики поведения мышки на ListView
        private void rectangles_lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (PZMap.Bmp == null)
                return;

            var rect = (MapZone)e.Item.Tag;

            if (e.IsSelected)
                rect.CurrentBrush = rect.SelectedBrush;
            else
                rect.CurrentBrush = rect.DefaultBrush;

            PZMap.Draw();
        }
        #endregion

        #region Обработчики TextBox
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

        #region Обработчики кнопок
        private void loadMap_btn_Click(object sender, EventArgs e)
        {
            if (PZMap.Bmp == null)
            {
                try
                {
                    loadMap_btn.Text = "Включаю...";
                    loadMap_btn.Enabled = false;

                    var mapFilePath = Properties.Settings.Default.MapFilePath;
                    if (mapFilePath == "default")
                    {
                        PZMap.LoadBitmap(Properties.Resources.pzmap);
                    }
                    else
                    {
                        if (!File.Exists(Properties.Settings.Default.MapFilePath))
                        {
                            MessageBox.Show("Указанный файл с картой не найден.\r\n" +
                                        "Проверьте настройки во вкладке \"Калибровка карты\".\r\n" +
                                        "Загружена карта по умолчанию.",
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                            PZMap.LoadBitmap(Properties.Resources.pzmap);
                        }
                        else
                        {
                            PZMap.LoadBitmap(new Bitmap(mapFilePath, false));
                        }
                    }

                    PZMap.Draw();
                }
                catch (Exception ex)
                {
                    UpdateControls();
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            else if (PZMap.Bmp != null)
            {
                if (PZMap.Zones.Count > 0)
                {
                    var result = MessageBox.Show("При выключении карты список зон будет очищен. Вы уверены, что хотите продолжить?\r\n\r\n",
                                                "Внимание",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button1,
                                                MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.No)
                        return;
                }

                PZMap.Zones.Clear();
                UpdateListView();
                PZMap.UnloadBitmap();
                PZMap_pb.Image = new Bitmap(PZMap_pb.Width, PZMap_pb.Height);
            }
        }
        private void clearAllRect_btn_Click(object sender, EventArgs e)
        {
            if (PZMap.Bmp == null)
            {
                ShowMessageWhenMapNotLoaded();
                return;
            }

            if (zones_lv.Items.Count == 0)
                return;

            PZMap.Zones.Clear();

            UpdateListView();
            PZMap.Draw();
        }
        private void clearSelectRect_Click(object sender, EventArgs e)
        {
            if (PZMap.Bmp == null)
            {
                ShowMessageWhenMapNotLoaded();
                return;
            }    

            if (zones_lv.Items.Count == 0)
                return;

            foreach (ListViewItem item in zones_lv.SelectedItems)
            {
                PZMap.Zones.Remove((MapZone)item.Tag);
            }
            UpdateListView();
            PZMap.Draw();
        }
        private void addZoneFromCoord_btn_Click(object sender, EventArgs e)
        {
            if (PZMap.Bmp == null)
            {
                ShowMessageWhenMapNotLoaded();
                return;
            }    

            try
            {
                if (string.IsNullOrEmpty(p1X_tb.Text) || string.IsNullOrEmpty(p1Y_tb.Text) || string.IsNullOrEmpty(p2X_tb.Text) || string.IsNullOrEmpty(p2Y_tb.Text))
                    return;

                MapCoordinates startPoint = new MapCoordinates(PZMap);
                startPoint.GameWorldCoords = new PointF(Convert.ToSingle(p1X_tb.Text), Convert.ToSingle(p1Y_tb.Text));

                MapCoordinates endPoint = new MapCoordinates(PZMap);
                endPoint.GameWorldCoords = new PointF(Convert.ToSingle(p2X_tb.Text), Convert.ToSingle(p2Y_tb.Text));

                var zone = new MapZone((MapZoneType)selectTypeAddZone_cb.SelectedIndex);
                zone.SetPointsViaGameWorld(startPoint, endPoint, PZMap);

                PZMap.Zones.Add(zone);
                UpdateListView();
                PZMap.Draw();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка при добавлении координат: {ex.Message}");
            }
        }
        private void importZones_btn_Click(object sender, EventArgs e)
        {
            if (PZMap.Bmp == null)
            {
                ShowMessageWhenMapNotLoaded();
                return;
            }

            if (ChoiceImportZonesFilePath.ShowDialog() == DialogResult.Cancel)
                return;

            var result = MessageBox.Show("Добавить импортируемые зоны к уже имеющимся на карте?\r\n\r\n" +
                                        "\"Да\" - означает, что зоны будут добавлены к уже имеющимся на карте игнорируя полные совпадения по типу и координатам;\r\n\r\n" +
                                        "\"Нет\" - означает, что перед импортом зон карта будет полностью очищена;",

                                        "Порядок импорта",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Cancel)
                return;

            ImportZones(result == DialogResult.Yes ? true : false);
        }
        private void exportZones_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PZMap.Bmp == null)
                {
                    ShowMessageWhenMapNotLoaded();
                    return;
                }

                if (ChoiceExportZonesFilePath.ShowDialog() == DialogResult.Cancel)
                    return;

                ExportZones();
                MessageBox.Show("Экспортировано успешно.", "Отчёт об экспорте",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information,
                                            MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При экспорте произошла ошибка: {ex.Message}", "Отчёт об экспорте",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void mapСalibration_btn_Click(object sender, EventArgs e)
        {
            MapCalibrationForm calibrationForm = new MapCalibrationForm();
            MainForm mainForm = FormManager.Forms.Find(m => m.GetType() == typeof(MainForm)) as MainForm;

            calibrationForm.Location = new Point((mainForm.Location.X + mainForm.Width / 2) - calibrationForm.Width/2, (mainForm.Location.Y + mainForm.Height / 2) - calibrationForm.Height/2);
            calibrationForm.ShowDialog();
        }
        private void mapResetSettings_btn_Click(object sender, EventArgs e)
        {
            MapResetMenuForm mapResetSettingsForm = new MapResetMenuForm();
            MainForm mainForm = FormManager.Forms.Find(m => m.GetType() == typeof(MainForm)) as MainForm;

            mapResetSettingsForm.Location = new Point((mainForm.Location.X + mainForm.Width / 2) - mapResetSettingsForm.Width / 2, (mainForm.Location.Y + mainForm.Height / 2) - mapResetSettingsForm.Height / 2);
            mapResetSettingsForm.ShowDialog();
        }
        #endregion
    }
}