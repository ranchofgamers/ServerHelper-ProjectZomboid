namespace ServerHelper.Forms
{
    partial class GSSChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.GSSChartBox = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GSSChartBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GSSChartBox
            // 
            this.GSSChartBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GSSChartBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GSSChartBox.BorderlineColor = System.Drawing.Color.Empty;
            this.GSSChartBox.BorderlineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            chartArea1.Name = "ChartArea1";
            this.GSSChartBox.ChartAreas.Add(chartArea1);
            this.GSSChartBox.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            legend1.Font = new System.Drawing.Font("Constantia", 12F);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.GSSChartBox.Legends.Add(legend1);
            this.GSSChartBox.Location = new System.Drawing.Point(0, 0);
            this.GSSChartBox.Name = "GSSChartBox";
            this.GSSChartBox.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Constantia", 12F);
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.LabelBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.Label = "#PERCENT{P}";
            dataPoint1.LegendText = "Amelia";
            dataPoint2.Label = "#PERCENT{P}";
            dataPoint2.LegendText = "John";
            dataPoint3.Label = "#PERCENT{P}";
            dataPoint3.LegendText = "Company";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.ShadowColor = System.Drawing.Color.Empty;
            this.GSSChartBox.Series.Add(series1);
            this.GSSChartBox.Size = new System.Drawing.Size(884, 761);
            this.GSSChartBox.TabIndex = 1;
            this.GSSChartBox.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.DockedToChartArea = "ChartArea1";
            title1.Font = new System.Drawing.Font("Book Antiqua", 18F);
            title1.ForeColor = System.Drawing.Color.White;
            title1.IsDockedInsideChartArea = false;
            title1.Name = "Title1";
            title1.Text = "TITLE";
            this.GSSChartBox.Titles.Add(title1);
            // 
            // GSSChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.GSSChartBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(900, 800);
            this.MinimumSize = new System.Drawing.Size(900, 800);
            this.Name = "GSSChartForm";
            this.Text = "GSS График";
            ((System.ComponentModel.ISupportInitialize)(this.GSSChartBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GSSChartBox;
    }
}