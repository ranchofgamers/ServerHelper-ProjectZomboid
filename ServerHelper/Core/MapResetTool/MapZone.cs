using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ServerHelper.Core.MapResetTool
{
    public class MapZone
    {
        public MapCoordinates LeftTopPoint { get; private set; }
        public MapCoordinates RightBotPoint { get; private set; }
        public SolidBrush DefaultBrush { get; set; }
        public SolidBrush CurrentBrush { get; set; }
        public SolidBrush SelectedBrush { get; set; }
        public MapZoneType Type { get; set; }

        public MapZone(MapZoneType type)
        {
            switch (type)
            {
                case MapZoneType.Reset:
                    DefaultBrush = new SolidBrush(Color.FromArgb(128, 200, 35, 35));
                    break;
                case MapZoneType.Claim:
                    DefaultBrush = new SolidBrush(Color.FromArgb(128, 170, 0, 255));
                    break;
                case MapZoneType.NoZombiesTerritory:
                    DefaultBrush = new SolidBrush(Color.FromArgb(128, 40, 180, 60));
                    break;
                case MapZoneType.ProhibitionOfDestruction:
                    DefaultBrush = new SolidBrush(Color.FromArgb(128, 180, 190, 45));
                    break;
                default:
                    break;
            }

            SelectedBrush = new SolidBrush(Color.FromArgb(128, 121, 121, 121));
            CurrentBrush = DefaultBrush;
            Type = type;
        }
        public void SetPointsViaView(MapCoordinates startPoint, MapCoordinates endPoint, Map map)
        {
            if (startPoint == null || endPoint == null)
                throw new NullReferenceException("Одна из координат равна null");

            var recalc = RecalcLeftTopAndRightBotPoints(startPoint.ViewCoords, endPoint.ViewCoords);

            LeftTopPoint = new MapCoordinates(map) { ViewCoords = recalc[0] };
            RightBotPoint = new MapCoordinates(map) { ViewCoords = recalc[1] };
        }
        public void SetPointsViaImage(MapCoordinates startPoint, MapCoordinates endPoint, Map map)
        {
            if (startPoint == null || endPoint == null)
                throw new NullReferenceException("Одна из координат равна null");

            var recalc = RecalcLeftTopAndRightBotPoints(startPoint.ImageCoords, endPoint.ImageCoords);

            LeftTopPoint = new MapCoordinates(map) { ImageCoords = recalc[0] };
            RightBotPoint = new MapCoordinates(map) { ImageCoords = recalc[1] };
        }
        public void SetPointsViaGameWorld(MapCoordinates startPoint, MapCoordinates endPoint, Map map)
        {
            if (startPoint == null || endPoint == null)
                throw new NullReferenceException("Одна из координат равна null");

            var recalc = RecalcLeftTopAndRightBotPoints(startPoint.GameWorldCoords, endPoint.GameWorldCoords);

            LeftTopPoint = new MapCoordinates(map) { GameWorldCoords = recalc[0] };
            RightBotPoint = new MapCoordinates(map) { GameWorldCoords = recalc[1] };
        }
        public void SetMapToPoints(Map map)
        {
            LeftTopPoint.Map = map;
            RightBotPoint.Map = map;
        }
        public Rectangle GetViewZone()
        {
            return new Rectangle(
                                (int)Math.Round(LeftTopPoint.ViewCoords.X, MidpointRounding.AwayFromZero),
                                (int)Math.Round(LeftTopPoint.ViewCoords.Y, MidpointRounding.AwayFromZero),
                                (int)Math.Round(RightBotPoint.ViewCoords.X - LeftTopPoint.ViewCoords.X, MidpointRounding.AwayFromZero),
                                (int)Math.Round(RightBotPoint.ViewCoords.Y - LeftTopPoint.ViewCoords.Y, MidpointRounding.AwayFromZero));
        }
        public static void ZonesSerialize(List<MapZone> zones, string path, string type)
        {            
            //TODO: ID или заменить на название?
            string result = "";

            MapZoneType mapZoneType;
            if (!Enum.TryParse(type, out mapZoneType))
                if (type != "All")
                    throw new ArgumentException("Указанный type зон не существует");

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                if (zones.Count == 0)
                {
                    byte[] buffer = Encoding.Default.GetBytes(result);
                    fs.Write(buffer, 0, buffer.Length);
                    return;
                }
                else
                {
                    IEnumerable<MapZone> zonesEnum;

                    if (type == "All")
                        zonesEnum = zones;
                    else
                        zonesEnum = zones.Where(t => t.Type == mapZoneType);

                    int counter = 0;
                    foreach (var zone in zonesEnum)
                    {
                        result +=
                            "{\n" +
                            $"ID={counter};\n" +
                            $"\tType={zone.Type};\n" +
                            $"\tLT=[{zone.LeftTopPoint.GameWorldCoords.X}x{zone.LeftTopPoint.GameWorldCoords.Y}];\n" +
                            $"\tRB=[{zone.RightBotPoint.GameWorldCoords.X}x{zone.RightBotPoint.GameWorldCoords.Y}];\n" +
                            "}\n\n";

                        counter++;
                    }
                    byte[] buffer = Encoding.Default.GetBytes(result);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }
        public static List<MapZone> ZonesDeserialize(string path, string type, in List<DeserializeZoneReport> report = null)
        {
            MapZoneType targetZoneType;
            if (!Enum.TryParse(type, out targetZoneType))
                if (type != "All")
                    throw new ArgumentException("Указанный type зон не существует");

            using (FileStream fs = File.OpenRead(path))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                Regex clearEscapesFilter = new Regex(@"\s");

                string result = Encoding.Default.GetString(buffer);
                result = clearEscapesFilter.Replace(result, string.Empty);

                Regex zonesBorderFilter = new Regex(@"\{(.*?)\}");
                var allMatches = zonesBorderFilter.Matches(result);

                List<MapZone> zones = new List<MapZone>();
                string ID = null;

                foreach (Match match in allMatches)
                {
                    try
                    {
                        var stringZone = match.Value;
                        var splitStringZone = stringZone
                            .Replace("{", string.Empty)
                            .Replace("}", string.Empty)
                            .Split(';')
                            .Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        var findID = splitStringZone.Where(x => x.Contains("ID")).First();
                        ID = findID.Split('=')[1];

                        if (splitStringZone.Length != 4)
                            throw new DeserializeZoneReport($"Ошибка при разбиении аргументов. Количество аргументов {splitStringZone.Length} != 4", ID, DeserializeType.Error);

                        MapZoneType findZoneType;
                        var findType = splitStringZone.Where(x => x.Contains("Type")).First().Split('=')[1];
                        if (!Enum.TryParse(findType, out findZoneType))
                            throw new DeserializeZoneReport($"Неизвестный тип зоны \"{findType}\"", ID, DeserializeType.Error);

                        if (type != "All" && findZoneType != targetZoneType)
                        {
                            if (report != null)
                                report.Add(new DeserializeZoneReport(null, ID, DeserializeType.Skipped));
                            continue;
                        }

                        var findLT = splitStringZone.Where(x => x.Contains("LT")).First();
                        var zoneLT = findLT.Split('=')[1].
                                                        Replace("[", string.Empty).
                                                        Replace("]", string.Empty).
                                                        Split('x');

                        var findRB = splitStringZone.Where(x => x.Contains("RB")).First();
                        var zoneRB = findRB.Split('=')[1].
                                                        Replace("[", string.Empty).
                                                        Replace("]", string.Empty).
                                                        Split('x');

                        var separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                        var leftTopPoint = new MapCoordinates();
                        var rightBotPoint = new MapCoordinates();

                        leftTopPoint.GameWorldCoords = new PointF(Convert.ToSingle(zoneLT[0].Replace(',', separator)), Convert.ToSingle(zoneLT[1].Replace(',', separator)));
                        rightBotPoint.GameWorldCoords = new PointF(Convert.ToSingle(zoneRB[0].Replace(',', separator)), Convert.ToSingle(zoneRB[1].Replace(',', separator)));

                        var zone = new MapZone(findZoneType);
                        zone.SetPointsViaGameWorld(leftTopPoint, rightBotPoint, null);
                        zones.Add(zone);
                        if(report != null)
                            report.Add(new DeserializeZoneReport(null, ID, DeserializeType.Successfully));
                    }
                    catch (Exception ex)
                    {
                        if (report != null)
                            report.Add(new DeserializeZoneReport(ex.Message, ID, DeserializeType.Error));
                        continue;
                    }
                }
                return zones;
            }
        }
        private PointF[] RecalcLeftTopAndRightBotPoints(PointF start, PointF end)
        {
            PointF lt = new PointF(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
            PointF rb = new PointF(lt.X + Math.Abs(end.X - start.X), lt.Y + Math.Abs(end.Y - start.Y));

            return new PointF[2] { lt, rb };
        }
    }
    public enum MapZoneType
    {
        Reset,
        Claim,
        NoZombiesTerritory,
        ProhibitionOfDestruction,
    }
}
