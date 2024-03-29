﻿namespace ServerHelper.Forms
{
    partial class DiscordForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.botLog_rtb = new System.Windows.Forms.RichTextBox();
            this.EverySecond = new System.Windows.Forms.Timer(this.components);
            this.ChoiceSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.SendChartTimer = new System.Windows.Forms.Timer(this.components);
            this.TenSecondsAfterStartApp = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botToken_tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartSourcePath_tb = new System.Windows.Forms.TextBox();
            this.changeSourcePath_btn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendChartChannelId_tb = new System.Windows.Forms.TextBox();
            this.isSendChart_cb = new System.Windows.Forms.CheckBox();
            this.botConnect_btn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sendChartInterval_tb = new System.Windows.Forms.TextBox();
            this.saveSettings_btn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.addGSS_tb = new System.Windows.Forms.TextBox();
            this.addGSS_btn = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.removeGSS_tb = new System.Windows.Forms.TextBox();
            this.removeGSS_btn = new System.Windows.Forms.Button();
            this.botStatus_lbl = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.sendImageServerId_tb = new System.Windows.Forms.TextBox();
            this.sendExecuteChart_btn = new System.Windows.Forms.Button();
            this.isBotAutoRestart_cb = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.openGSSChartForm_btn = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.botLog_rtb);
            this.groupBox6.Location = new System.Drawing.Point(334, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(316, 630);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Лог бота:";
            // 
            // botLog_rtb
            // 
            this.botLog_rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botLog_rtb.Location = new System.Drawing.Point(3, 16);
            this.botLog_rtb.Name = "botLog_rtb";
            this.botLog_rtb.ReadOnly = true;
            this.botLog_rtb.Size = new System.Drawing.Size(310, 611);
            this.botLog_rtb.TabIndex = 0;
            this.botLog_rtb.Text = "";
            // 
            // EverySecond
            // 
            this.EverySecond.Interval = 1000;
            // 
            // ChoiceSourceFile
            // 
            this.ChoiceSourceFile.FileName = "Statistic";
            this.ChoiceSourceFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            // 
            // SendChartTimer
            // 
            this.SendChartTimer.Interval = 1000;
            // 
            // TenSecondsAfterStartApp
            // 
            this.TenSecondsAfterStartApp.Interval = 10000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botToken_tb);
            this.groupBox2.Location = new System.Drawing.Point(6, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Токен бота:";
            // 
            // botToken_tb
            // 
            this.botToken_tb.Location = new System.Drawing.Point(12, 19);
            this.botToken_tb.Name = "botToken_tb";
            this.botToken_tb.Size = new System.Drawing.Size(280, 20);
            this.botToken_tb.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeSourcePath_btn);
            this.groupBox1.Controls.Add(this.chartSourcePath_tb);
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл с данными  для графика:";
            // 
            // chartSourcePath_tb
            // 
            this.chartSourcePath_tb.Location = new System.Drawing.Point(9, 19);
            this.chartSourcePath_tb.Name = "chartSourcePath_tb";
            this.chartSourcePath_tb.ReadOnly = true;
            this.chartSourcePath_tb.Size = new System.Drawing.Size(205, 20);
            this.chartSourcePath_tb.TabIndex = 1;
            // 
            // changeSourcePath_btn
            // 
            this.changeSourcePath_btn.ForeColor = System.Drawing.Color.Black;
            this.changeSourcePath_btn.Location = new System.Drawing.Point(220, 17);
            this.changeSourcePath_btn.Name = "changeSourcePath_btn";
            this.changeSourcePath_btn.Size = new System.Drawing.Size(69, 23);
            this.changeSourcePath_btn.TabIndex = 2;
            this.changeSourcePath_btn.Text = "Изменить";
            this.changeSourcePath_btn.UseVisualStyleBackColor = true;
            this.changeSourcePath_btn.Click += new System.EventHandler(this.changeSourcePath_btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sendChartChannelId_tb);
            this.groupBox4.Location = new System.Drawing.Point(166, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(138, 48);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ID канала:";
            // 
            // sendChartChannelId_tb
            // 
            this.sendChartChannelId_tb.Location = new System.Drawing.Point(6, 19);
            this.sendChartChannelId_tb.Name = "sendChartChannelId_tb";
            this.sendChartChannelId_tb.Size = new System.Drawing.Size(126, 20);
            this.sendChartChannelId_tb.TabIndex = 1;
            this.sendChartChannelId_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTB_KeyPress);
            // 
            // isSendChart_cb
            // 
            this.isSendChart_cb.AutoSize = true;
            this.isSendChart_cb.ForeColor = System.Drawing.Color.Black;
            this.isSendChart_cb.Location = new System.Drawing.Point(15, 135);
            this.isSendChart_cb.Name = "isSendChart_cb";
            this.isSendChart_cb.Size = new System.Drawing.Size(212, 17);
            this.isSendChart_cb.TabIndex = 7;
            this.isSendChart_cb.Text = "Включить отправку графика в канал";
            this.isSendChart_cb.UseVisualStyleBackColor = true;
            // 
            // botConnect_btn
            // 
            this.botConnect_btn.ForeColor = System.Drawing.Color.Black;
            this.botConnect_btn.Location = new System.Drawing.Point(15, 178);
            this.botConnect_btn.Name = "botConnect_btn";
            this.botConnect_btn.Size = new System.Drawing.Size(283, 50);
            this.botConnect_btn.TabIndex = 8;
            this.botConnect_btn.Text = "Подключить";
            this.botConnect_btn.UseVisualStyleBackColor = true;
            this.botConnect_btn.Click += new System.EventHandler(this.botConnect_btn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sendChartInterval_tb);
            this.groupBox5.Location = new System.Drawing.Point(6, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 48);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Интервал отправки (мин):";
            // 
            // sendChartInterval_tb
            // 
            this.sendChartInterval_tb.Location = new System.Drawing.Point(9, 19);
            this.sendChartInterval_tb.Name = "sendChartInterval_tb";
            this.sendChartInterval_tb.Size = new System.Drawing.Size(130, 20);
            this.sendChartInterval_tb.TabIndex = 1;
            this.sendChartInterval_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTB_KeyPress);
            // 
            // saveSettings_btn
            // 
            this.saveSettings_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettings_btn.ForeColor = System.Drawing.Color.Black;
            this.saveSettings_btn.Location = new System.Drawing.Point(856, 659);
            this.saveSettings_btn.Name = "saveSettings_btn";
            this.saveSettings_btn.Size = new System.Drawing.Size(316, 50);
            this.saveSettings_btn.TabIndex = 9;
            this.saveSettings_btn.Text = "Сохранить настройки";
            this.saveSettings_btn.UseVisualStyleBackColor = true;
            this.saveSettings_btn.Click += new System.EventHandler(this.saveSettings_btn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.addGSS_btn);
            this.groupBox7.Controls.Add(this.addGSS_tb);
            this.groupBox7.Location = new System.Drawing.Point(6, 201);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(295, 48);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Добавить GSS на график:";
            // 
            // addGSS_tb
            // 
            this.addGSS_tb.Location = new System.Drawing.Point(6, 19);
            this.addGSS_tb.Name = "addGSS_tb";
            this.addGSS_tb.Size = new System.Drawing.Size(196, 20);
            this.addGSS_tb.TabIndex = 1;
            // 
            // addGSS_btn
            // 
            this.addGSS_btn.ForeColor = System.Drawing.Color.Black;
            this.addGSS_btn.Location = new System.Drawing.Point(208, 17);
            this.addGSS_btn.Name = "addGSS_btn";
            this.addGSS_btn.Size = new System.Drawing.Size(75, 23);
            this.addGSS_btn.TabIndex = 3;
            this.addGSS_btn.Text = "Добавить";
            this.addGSS_btn.UseVisualStyleBackColor = true;
            this.addGSS_btn.Click += new System.EventHandler(this.addGSS_btn_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.removeGSS_btn);
            this.groupBox8.Controls.Add(this.removeGSS_tb);
            this.groupBox8.Location = new System.Drawing.Point(6, 255);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(295, 48);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Удалить GSS с графика:";
            // 
            // removeGSS_tb
            // 
            this.removeGSS_tb.Location = new System.Drawing.Point(6, 19);
            this.removeGSS_tb.Name = "removeGSS_tb";
            this.removeGSS_tb.Size = new System.Drawing.Size(196, 20);
            this.removeGSS_tb.TabIndex = 1;
            // 
            // removeGSS_btn
            // 
            this.removeGSS_btn.ForeColor = System.Drawing.Color.Black;
            this.removeGSS_btn.Location = new System.Drawing.Point(208, 17);
            this.removeGSS_btn.Name = "removeGSS_btn";
            this.removeGSS_btn.Size = new System.Drawing.Size(75, 23);
            this.removeGSS_btn.TabIndex = 3;
            this.removeGSS_btn.Text = "Удалить";
            this.removeGSS_btn.UseVisualStyleBackColor = true;
            this.removeGSS_btn.Click += new System.EventHandler(this.removeGSS_btn_Click);
            // 
            // botStatus_lbl
            // 
            this.botStatus_lbl.AutoSize = true;
            this.botStatus_lbl.ForeColor = System.Drawing.Color.Red;
            this.botStatus_lbl.Location = new System.Drawing.Point(6, 16);
            this.botStatus_lbl.Name = "botStatus_lbl";
            this.botStatus_lbl.Size = new System.Drawing.Size(104, 13);
            this.botStatus_lbl.TabIndex = 26;
            this.botStatus_lbl.Text = "Статус Bot\'а: Offline";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.sendImageServerId_tb);
            this.groupBox9.Location = new System.Drawing.Point(6, 89);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(301, 48);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "ID сервера:";
            // 
            // sendImageServerId_tb
            // 
            this.sendImageServerId_tb.Location = new System.Drawing.Point(9, 19);
            this.sendImageServerId_tb.Name = "sendImageServerId_tb";
            this.sendImageServerId_tb.Size = new System.Drawing.Size(283, 20);
            this.sendImageServerId_tb.TabIndex = 1;
            this.sendImageServerId_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTB_KeyPress);
            // 
            // sendExecuteChart_btn
            // 
            this.sendExecuteChart_btn.ForeColor = System.Drawing.Color.Black;
            this.sendExecuteChart_btn.Location = new System.Drawing.Point(15, 158);
            this.sendExecuteChart_btn.Name = "sendExecuteChart_btn";
            this.sendExecuteChart_btn.Size = new System.Drawing.Size(283, 37);
            this.sendExecuteChart_btn.TabIndex = 1;
            this.sendExecuteChart_btn.Text = "Отправить график принудительно";
            this.sendExecuteChart_btn.UseVisualStyleBackColor = true;
            this.sendExecuteChart_btn.Click += new System.EventHandler(this.sendExecuteChart_btn_Click);
            // 
            // isBotAutoRestart_cb
            // 
            this.isBotAutoRestart_cb.AutoSize = true;
            this.isBotAutoRestart_cb.ForeColor = System.Drawing.Color.Black;
            this.isBotAutoRestart_cb.Location = new System.Drawing.Point(15, 148);
            this.isBotAutoRestart_cb.Name = "isBotAutoRestart_cb";
            this.isBotAutoRestart_cb.Size = new System.Drawing.Size(230, 17);
            this.isBotAutoRestart_cb.TabIndex = 27;
            this.isBotAutoRestart_cb.Text = "Автоматическое переподключение бота";
            this.isBotAutoRestart_cb.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.botConnect_btn);
            this.groupBox3.Controls.Add(this.isBotAutoRestart_cb);
            this.groupBox3.Controls.Add(this.botStatus_lbl);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 249);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройки бота:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.openGSSChartForm_btn);
            this.groupBox10.Controls.Add(this.isSendChart_cb);
            this.groupBox10.Controls.Add(this.groupBox1);
            this.groupBox10.Controls.Add(this.groupBox5);
            this.groupBox10.Controls.Add(this.groupBox4);
            this.groupBox10.Controls.Add(this.sendExecuteChart_btn);
            this.groupBox10.Controls.Add(this.groupBox7);
            this.groupBox10.Controls.Add(this.groupBox8);
            this.groupBox10.Location = new System.Drawing.Point(12, 267);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(316, 375);
            this.groupBox10.TabIndex = 28;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "GSS График:";
            // 
            // openGSSChartForm_btn
            // 
            this.openGSSChartForm_btn.ForeColor = System.Drawing.Color.Black;
            this.openGSSChartForm_btn.Location = new System.Drawing.Point(15, 319);
            this.openGSSChartForm_btn.Name = "openGSSChartForm_btn";
            this.openGSSChartForm_btn.Size = new System.Drawing.Size(283, 37);
            this.openGSSChartForm_btn.TabIndex = 9;
            this.openGSSChartForm_btn.Text = "Открыть окно с графиком";
            this.openGSSChartForm_btn.UseVisualStyleBackColor = true;
            this.openGSSChartForm_btn.Click += new System.EventHandler(this.openGSSChartForm_btn_Click);
            // 
            // DiscordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1184, 721);
            this.Controls.Add(this.saveSettings_btn);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Name = "DiscordForm";
            this.Text = "Дискорд бот";
            this.groupBox6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox botLog_rtb;
        private System.Windows.Forms.Timer EverySecond;
        private System.Windows.Forms.OpenFileDialog ChoiceSourceFile;
        private System.Windows.Forms.Timer SendChartTimer;
        private System.Windows.Forms.Timer TenSecondsAfterStartApp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox botToken_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button changeSourcePath_btn;
        private System.Windows.Forms.TextBox chartSourcePath_tb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox sendChartChannelId_tb;
        private System.Windows.Forms.CheckBox isSendChart_cb;
        private System.Windows.Forms.Button botConnect_btn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox sendChartInterval_tb;
        private System.Windows.Forms.Button saveSettings_btn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button addGSS_btn;
        private System.Windows.Forms.TextBox addGSS_tb;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button removeGSS_btn;
        private System.Windows.Forms.TextBox removeGSS_tb;
        private System.Windows.Forms.Label botStatus_lbl;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox sendImageServerId_tb;
        private System.Windows.Forms.Button sendExecuteChart_btn;
        private System.Windows.Forms.CheckBox isBotAutoRestart_cb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button openGSSChartForm_btn;
    }
}