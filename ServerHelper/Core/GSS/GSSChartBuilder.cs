using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using ServerHelper.Properties;

namespace ServerHelper.Core
{
    public class GSSChartBuilder: IModule
    {
        public string Name { get; private set; }
        public string SourceFile { get; private set; }
        public Guid ModuleID { get; private set; }
        public bool IsSaving { get; private set; }
        public bool IsUpdating { get; private set; }
        public Chart Chart
        {
            get { return chart; }
            private set
            {
                CheckValidChart(value);
                chart = value;
            }
        }
        private Chart chart;

        private string dataDirectory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.DataFolder}\\ChartsData";

        public GSSChartBuilder(string name, string source, Chart chart)
        {
            Name = name;
            SourceFile = source;
            Chart = chart;

            ModuleID = Guid.NewGuid();
            ModuleManager.RegisterModule(this);
        }

        public async Task UpdateGraphAsync()
        {
            if (IsUpdating)
                throw new InvalidOperationException("Отказано в доступе, график уже обновляется");
           
            IsUpdating = true;

            await Task.Run(() =>
            {
                try
                {
                    Chart.Invoke((Action)(() =>
                    {
                        List<StatInfo> statInfos = BuildStatistics(ReadSource(SourceFile));

                        if (statInfos.Count == 0)
                        {
                            Chart.Titles[0].Text = "Ошибка загрузки данных";
                            foreach (var point in Chart.Series[0].Points)
                            {
                                point.YValues[0] = 1;
                            }
                            return;
                        }

                        Chart.Titles[0].Text = String.Format("{0} UTC", DateTime.UtcNow.ToString(new CultureInfo("ru-RU")));

                        foreach (var point in Chart.Series[0].Points)
                        {
                            foreach (var stat in statInfos)
                            {
                                if (point.LegendText == stat.Name)
                                {
                                    point.YValues[0] = stat.Value;
                                }
                            }
                        }
                    }));
                }
                catch (Exception) { throw; }
                finally { IsUpdating = false; }
            });
        }
        public async Task<string> SaveImageAsync()
        {
            if (IsSaving)
                throw new InvalidOperationException("Отказано в доступе, график уже сохраняется");

            IsSaving = true;

            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            await Task.Run(() =>
            {
                try
                {
                    Chart.Invoke((Action)(() =>
                    {            
                        try
                        {       
                            Chart.SaveImage($"{dataDirectory}\\{Name}.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (IOException) { }
                    }));
                }
                catch (Exception) { throw; }
                finally { IsSaving = false; }
            });

            return $"{dataDirectory}\\{Name}.png";
        }
        public void UpdateInfo(string name = default, string source = default, Chart chart = default)
        {
            if (IsSaving)
                throw new InvalidOperationException("Отказано в доступе, график сохраняется, невозможно обновить данные");

            if (name != default)
                Name = name;
            if(source != default)
                SourceFile = source;
            if(chart != default)
                Chart = chart;
        }
        public void Serialize()
        {
            chart.Serializer.Save($"{dataDirectory}\\{Name}.dat");
        }
        public void Serialize(string path)
        {
            chart.Serializer.Save(path);
        }
        public bool Deserialize()
        {
            return Deserialize($"{dataDirectory}\\{Name}.dat");
        }
        public bool Deserialize(string path)
        {
            if (File.Exists(path))
            {
                chart.Serializer.Load(path);
                return true;
            }
            else return false;
        }
        public IModule GetModule()
        {
            return this;
        }

        private void CheckValidChart(Chart chart)
        {
            if (chart.Titles.Count < 1)
                throw new ArgumentException("График должен содержать как минимум 1 заголовок для отображения времени.");

            if (chart.Series.Count < 1)
                throw new ArgumentException("График должен содержать как минимум одну серию точек для отображения информации.");

            if (chart.Series[0].ChartType != SeriesChartType.Doughnut && chart.Series[0].ChartType != SeriesChartType.Pie)
                throw new ArgumentException("График должен иметь тип круговой или кольцевой диаграммы.");
        }
        private string ReadSource(string path)
        {
            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            if (File.Exists(path))
                File.Copy(path, $"{dataDirectory}\\{Name}.src", true);
            else if (!File.Exists($"{dataDirectory}\\{Name}.src"))
                return null;

            using (FileStream fs = new FileStream($"{dataDirectory}\\{Name}.src", FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader rs = new StreamReader(fs))
            {
                string source = string.Empty;
                string line = string.Empty;

                while (line != null)
                {
                    line = rs.ReadLine();
                    if (line != null)
                        source = source + line;
                }

                return source;
            }
        }
        private List<StatInfo> BuildStatistics(string source)
        {
            if (source == null || source == string.Empty)
                return new List<StatInfo>();

            string[] statInfo = source.Trim().Split(';');

            if (statInfo.Length == 0)
                return new List<StatInfo>();

            List<StatInfo> statisticInfos = new List<StatInfo>();

            for (int i = 0; i < statInfo.Length; i++)
            {
                if (statInfo[i] == string.Empty)
                    continue;

                string[] splitStatInfo = statInfo[i].Trim().Split(':');
                if (splitStatInfo.Length != 2)
                    continue;

                if (splitStatInfo[0] == null || splitStatInfo[0] == string.Empty)
                    splitStatInfo[0] = "Unknown";

                if (splitStatInfo[1] == null || splitStatInfo[1] == string.Empty)
                    splitStatInfo[1] = "0";

                double statValue;
                try { statValue = Convert.ToDouble(splitStatInfo[1]); }
                catch (Exception) { statValue = 0; }

                statisticInfos.Add(new StatInfo(splitStatInfo[0], statValue));
            }

            return statisticInfos;
        }

        private struct StatInfo
        {
            public string Name { get; private set; }
            public double Value { get; private set; }
            public StatInfo(string name, double value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
