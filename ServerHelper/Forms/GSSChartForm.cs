using ServerHelper.Core;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Forms
{
    public partial class GSSChartForm : Form
    {
        public GSSChartBuilder GSSChart { get; private set; }

        public GSSChartForm()
        {
            InitializeComponent();

            GSSChart = new GSSChartBuilder("GSSChart", Settings.Default.GSSSourceFilePath, GSSChartBox);
            GSSChart.Deserialize();
        }

        public void AddGSS(string name)
        {
            var point = GSSChartBox.Series[0].Points.Add();
            point.SetValueXY(0, 1);
            point.Label = "#PERCENT{P}";
            point.LegendText = name;
            GSSChart.Serialize();
        }
        public void RemoveGSS(string name) 
        {
            var col = GSSChartBox.Series[0].Points;
            foreach (var point in col)
            {
                if (point.LegendText == name)
                {
                    GSSChartBox.Series[0].Points.Remove(point);
                    GSSChart.Serialize();
                    return;
                }
            }
        }
    }
}
