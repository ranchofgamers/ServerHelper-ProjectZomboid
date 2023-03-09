using Newtonsoft.Json;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Core.MapResetTool
{
    public class Map
    {
        public event Action OnBitmapLoad;
        public event Action OnBitmapUnload;
        public static event Action OnResetStarted;
        public static event Action OnResetEnded;

        public static bool IsReset { get; private set; }

        public PictureBox LinkedPictureBox { get; private set; }
        public Bitmap Bmp { get; private set; }
        public MapCoordinates PointerCoordinates { get; private set; }
        public List<MapZone> Zones { get; private set; }

        public PointF LT { get; set; } = new PointF(3000, 900);
        public PointF LB { get; set; }  = new PointF(3000, 13500);
        public PointF RT { get; set; }  = new PointF(15000, 900);
        public PointF RB { get; set; }  = new PointF(15000, 13500);

        public float Scl { get; private set; } = 0.45f;
        public float X0 { get; private set; } = 0;
        public float Y0 { get; private set; } = 0;
        public float XD { get; private set; } = -1;
        public float YD { get; private set; } = -1;

        private static CancellationTokenSource resetTaskCTS;

        public Map(PictureBox pictureBox)
        {
            if (pictureBox == null)
                throw new ArgumentNullException("Ссылка на PictureBox равна null");

            PointerCoordinates = new MapCoordinates(this);
            Zones = new List<MapZone>();
            LinkedPictureBox = pictureBox;
        }

        public static async Task<bool> ResetMapAsync(string mapSaveFolder, List<MapZone> zones, bool bypassPrivate = true, bool backupFiles = true, ProgressBar progressBar = null, Label currentFileLabel = null)
        {
            await Task.Run(() =>
            {
                ResetMap(mapSaveFolder, zones, bypassPrivate, backupFiles, progressBar, currentFileLabel);
            });
            return resetTaskCTS.IsCancellationRequested;
        }
        public static void ResetMap(string mapSaveFolder, List<MapZone> zones, bool bypassPrivate = true, bool backupFiles = true, ProgressBar progressBar = null, Label currentFileLabel = null)
        {
            if (IsReset)
                throw new InvalidOperationException("Сброс карты уже выполняется");

            IsReset = true;
            OnResetStarted?.Invoke();

            resetTaskCTS = new CancellationTokenSource();

            if (progressBar != null)
            {
                progressBar.Invoke((Action)(() => { progressBar.Style = ProgressBarStyle.Continuous; }));
                progressBar.Invoke((Action)(() => { progressBar.Value = 0; }));
            }

            string backupDirectory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.DataFolder}\\ResetBackups\\backup_{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-sstt")}";

            try
            {
                var files = Directory.GetFiles(mapSaveFolder);
                Regex pattern = new Regex(@"map_\d+_\d+\.bin");

                if (progressBar != null)
                    progressBar.Invoke((Action)(() => { progressBar.Maximum = files.Length; }));

                foreach (var file in files)
                {
                    if (resetTaskCTS.IsCancellationRequested)
                    {
                        if (progressBar != null)
                            progressBar.Invoke((Action)(() => { progressBar.Value = 0; }));
                        if (currentFileLabel != null)
                            currentFileLabel.Invoke((Action)(() => { currentFileLabel.Text = "Прервано"; }));
                        resetTaskCTS.Token.ThrowIfCancellationRequested();
                    }

                    try
                    {
                        if (progressBar != null)
                            progressBar.Invoke((Action)(() => { progressBar.Increment(1); }));
                        if (currentFileLabel != null)
                            currentFileLabel.Invoke((Action)(() => { currentFileLabel.Text = Path.GetFileName(file); }));

                        var cf = Path.GetFileNameWithoutExtension(file);

                        if (!pattern.IsMatch($"{cf}.bin"))
                            continue;

                        var scf = cf.Split('_');
                        var XChunk = Convert.ToInt32(scf[1]) * 10;
                        var YChunk = Convert.ToInt32(scf[2]) * 10;

                        foreach (var resetZone in zones.Where(t => t.Type == MapZoneType.Reset))
                        {
                            bool skip = false;

                            var RspX = resetZone.LeftTopPoint.GameWorldCoords.X;
                            var RspY = resetZone.LeftTopPoint.GameWorldCoords.Y;

                            var RepX = resetZone.RightBotPoint.GameWorldCoords.X;
                            var RepY = resetZone.RightBotPoint.GameWorldCoords.Y;

                            if ((XChunk + 10 > RspX && YChunk + 10 > RspY) && (XChunk < RepX && YChunk < RepY))
                            {
                                if (bypassPrivate)
                                {
                                    foreach (var claimZone in zones.Where(t => t.Type == MapZoneType.Claim))
                                    {
                                        var CspX = claimZone.LeftTopPoint.GameWorldCoords.X;
                                        var CspY = claimZone.LeftTopPoint.GameWorldCoords.Y;

                                        var CepX = claimZone.RightBotPoint.GameWorldCoords.X;
                                        var CepY = claimZone.RightBotPoint.GameWorldCoords.Y;

                                        if ((XChunk + 10 > CspX && YChunk + 10 > CspY) && (XChunk < CepX && YChunk < CepY))
                                        {
                                            skip = true;
                                            break;
                                        }
                                    }
                                    if (skip)
                                        continue;
                                }
                                if (!backupFiles)
                                    File.Delete(file);
                                else
                                {
                                    if (!Directory.Exists(backupDirectory))
                                        Directory.CreateDirectory(backupDirectory);

                                    File.Copy(file, $"{backupDirectory}\\{Path.GetFileName(file)}");
                                    File.Delete(file);
                                }
                            }
                        }
                    }
                    catch (Exception) { continue; }
                }
            }
            catch (Exception) { }
            finally
            {
                IsReset = false;
                OnResetEnded?.Invoke();
            }
        }
        public static void AbortReset()
        {
            if (!IsReset)
                return;

            resetTaskCTS.Cancel();
        }
        public void Draw()
        {
            if (Bmp == null)
                throw new InvalidOperationException("Bitmap не загружена");

            using (Graphics Gr = Graphics.FromImage(LinkedPictureBox.Image))
            {
                Gr.Clear(Color.Black);
                Gr.DrawImage(Bmp, X0, Y0, Bmp.Width * Scl, Bmp.Height * Scl);
                foreach (var zone in Zones)
                    DrawZone(Gr, zone);
            }
            LinkedPictureBox.Refresh();
        }
        public void DrawSelectRect(MapZone rect)
        {
            if (Bmp == null)
                throw new InvalidOperationException("Bitmap не загружена");

            Draw();
            using (Graphics Gr = Graphics.FromImage(LinkedPictureBox.Image))
                DrawZone(Gr, rect);

            LinkedPictureBox.Refresh();
        }
        public void PointerDown(int pointerX, int pointerY)
        {
            float x = X0 + Bmp.Width * Scl;
            float y = Y0 + Bmp.Height * Scl;
            if ((pointerX >= X0 && pointerY >= Y0) && (pointerX <= x && pointerY <= y))
            {
                XD = pointerX;
                YD = pointerY;
            }
        }
        public void MapMove(int pointerX, int pointerY)
        {
            X0 += pointerX - XD;
            Y0 += pointerY - YD;
            XD = pointerX;
            YD = pointerY;
            Draw();
        }
        public void MapScale(int pointerX, int pointerY, int pointerDelta)
        {
            float x = X0 + Bmp.Width * Scl;
            float y = Y0 + Bmp.Height * Scl;
            if (pointerX <= x && pointerY <= y)
            {
                x = (pointerX - X0) / Scl;
                y = (pointerY - Y0) / Scl;
                float ds = pointerDelta > 0 ? Scl * 1.25f : Scl / 1.25f;
                if (ds >= 0.1) Scl = ds;
                X0 = pointerX - x * Scl;
                Y0 = pointerY - y * Scl;
                Draw();
            }
        }
        public void ResetPointer()
        {
            XD = -1;
            YD = -1;
        }
        public void LoadBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("Ссыка на Bitmap равна null");

            Bmp = new Bitmap(bitmap);
            OnBitmapLoad?.Invoke();
        }
        public void UnloadBitmap()
        {
            Bmp.Dispose();
            Bmp = null;
            OnBitmapUnload?.Invoke();
        }
        private void DrawZone(Graphics Gr, MapZone rect)
        {
            if (Gr == null || rect == null)
                return;

            Gr.FillRectangle(rect.CurrentBrush, rect.GetViewZone());
            //var rectangleCenter = new PointF(rect.startPoint.ViewCoords.X + (rect.endPoint.ViewCoords.X - rect.startPoint.ViewCoords.X) / 2, rect.startPoint.ViewCoords.Y + (rect.endPoint.ViewCoords.Y - rect.startPoint.ViewCoords.Y) / 2);
            //Font lableFont = new Font("Times New Roman", 18*Scl);
            //Gr.DrawString(
            //    $"{rect.startPoint.GameWorldCoords.X} x {rect.startPoint.GameWorldCoords.Y}" +
            //    $"\r\n" +
            //    $"{rect.endPoint.GameWorldCoords.X} x {rect.endPoint.GameWorldCoords.Y}", 
            //    lableFont, Brushes.Black, 
            //    rectangleCenter.X, rectangleCenter.Y, 
            //    new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
    }
}