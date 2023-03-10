namespace ServerHelper.Forms
{
    partial class ServerHelperForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.isRconAutoRestart_cb = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.serverIP_tb = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rconPort_tb = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rconPassword_tb = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rconSendCommand_tb = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.serverResponce_rtb = new System.Windows.Forms.RichTextBox();
            this.rconStatus_lbl = new System.Windows.Forms.Label();
            this.rconSendCommand_btn = new System.Windows.Forms.Button();
            this.rconConnect_btn = new System.Windows.Forms.Button();
            this.saveRconSettings_btn = new System.Windows.Forms.Button();
            this.isServerAutoRestart_cb = new System.Windows.Forms.CheckBox();
            this.isSendRestartMsg_cb = new System.Windows.Forms.CheckBox();
            this.saveRestartSettings_bt = new System.Windows.Forms.Button();
            this.serverAutoRestart_lbl = new System.Windows.Forms.Label();
            this.changeServerStartFilePath_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.changeServerBackupFolderPath_btn = new System.Windows.Forms.Button();
            this.serverBackupFolderPath_tb = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.changeServerFolderPath_btn = new System.Windows.Forms.Button();
            this.serverFolderPath_tb = new System.Windows.Forms.TextBox();
            this.isMakeBackup_cb = new System.Windows.Forms.CheckBox();
            this.serverRestart_btn = new System.Windows.Forms.Button();
            this.serverStart_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.serverStartFilePath_tb = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.restartUtcTime_tb = new System.Windows.Forms.TextBox();
            this.ChoiceServerStartFilePath = new System.Windows.Forms.OpenFileDialog();
            this.EverySecond = new System.Windows.Forms.Timer(this.components);
            this.EveryTenSeconds = new System.Windows.Forms.Timer(this.components);
            this.RestartMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.ChoiceServerFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.ChoiceServerBackupFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.isRconAutoRestart_cb);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.rconStatus_lbl);
            this.groupBox3.Controls.Add(this.rconSendCommand_btn);
            this.groupBox3.Controls.Add(this.rconConnect_btn);
            this.groupBox3.Controls.Add(this.saveRconSettings_btn);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 491);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RCON";
            // 
            // isRconAutoRestart_cb
            // 
            this.isRconAutoRestart_cb.AutoSize = true;
            this.isRconAutoRestart_cb.ForeColor = System.Drawing.Color.Black;
            this.isRconAutoRestart_cb.Location = new System.Drawing.Point(12, 260);
            this.isRconAutoRestart_cb.Name = "isRconAutoRestart_cb";
            this.isRconAutoRestart_cb.Size = new System.Drawing.Size(159, 43);
            this.isRconAutoRestart_cb.TabIndex = 24;
            this.isRconAutoRestart_cb.Text = "Авто. подключение \r\n(только если сервер \r\nзапущен из под оболочки)";
            this.isRconAutoRestart_cb.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.serverIP_tb);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(6, 45);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(181, 48);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "IP сервера:";
            // 
            // serverIP_tb
            // 
            this.serverIP_tb.Location = new System.Drawing.Point(6, 19);
            this.serverIP_tb.Name = "serverIP_tb";
            this.serverIP_tb.Size = new System.Drawing.Size(169, 20);
            this.serverIP_tb.TabIndex = 1;
            this.serverIP_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPTB_KeyPress);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rconPort_tb);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(6, 99);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(181, 48);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Порт RCON:";
            // 
            // rconPort_tb
            // 
            this.rconPort_tb.Location = new System.Drawing.Point(6, 19);
            this.rconPort_tb.Name = "rconPort_tb";
            this.rconPort_tb.Size = new System.Drawing.Size(169, 20);
            this.rconPort_tb.TabIndex = 1;
            this.rconPort_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTB_KeyPress);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rconPassword_tb);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(6, 153);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(181, 48);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Пароль RCON:";
            // 
            // rconPassword_tb
            // 
            this.rconPassword_tb.Location = new System.Drawing.Point(6, 19);
            this.rconPassword_tb.Name = "rconPassword_tb";
            this.rconPassword_tb.PasswordChar = '*';
            this.rconPassword_tb.Size = new System.Drawing.Size(169, 20);
            this.rconPassword_tb.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rconSendCommand_tb);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(199, 386);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(239, 48);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Отправить команду по RCON:";
            // 
            // rconSendCommand_tb
            // 
            this.rconSendCommand_tb.Location = new System.Drawing.Point(6, 19);
            this.rconSendCommand_tb.Name = "rconSendCommand_tb";
            this.rconSendCommand_tb.Size = new System.Drawing.Size(227, 20);
            this.rconSendCommand_tb.TabIndex = 1;
            this.rconSendCommand_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rconSendCommand_tb_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.serverResponce_rtb);
            this.groupBox4.Location = new System.Drawing.Point(199, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 341);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ответ сервера";
            // 
            // serverResponce_rtb
            // 
            this.serverResponce_rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverResponce_rtb.Location = new System.Drawing.Point(3, 16);
            this.serverResponce_rtb.Name = "serverResponce_rtb";
            this.serverResponce_rtb.ReadOnly = true;
            this.serverResponce_rtb.Size = new System.Drawing.Size(236, 322);
            this.serverResponce_rtb.TabIndex = 23;
            this.serverResponce_rtb.Text = "";
            // 
            // rconStatus_lbl
            // 
            this.rconStatus_lbl.AutoSize = true;
            this.rconStatus_lbl.ForeColor = System.Drawing.Color.Red;
            this.rconStatus_lbl.Location = new System.Drawing.Point(199, 16);
            this.rconStatus_lbl.Name = "rconStatus_lbl";
            this.rconStatus_lbl.Size = new System.Drawing.Size(109, 13);
            this.rconStatus_lbl.TabIndex = 18;
            this.rconStatus_lbl.Text = "Статус RCON: offline";
            // 
            // rconSendCommand_btn
            // 
            this.rconSendCommand_btn.ForeColor = System.Drawing.Color.Black;
            this.rconSendCommand_btn.Location = new System.Drawing.Point(199, 438);
            this.rconSendCommand_btn.Name = "rconSendCommand_btn";
            this.rconSendCommand_btn.Size = new System.Drawing.Size(239, 40);
            this.rconSendCommand_btn.TabIndex = 17;
            this.rconSendCommand_btn.Text = "Отправить";
            this.rconSendCommand_btn.UseVisualStyleBackColor = true;
            this.rconSendCommand_btn.Click += new System.EventHandler(this.rconSendCommand_btn_Click);
            // 
            // rconConnect_btn
            // 
            this.rconConnect_btn.ForeColor = System.Drawing.Color.Black;
            this.rconConnect_btn.Location = new System.Drawing.Point(12, 223);
            this.rconConnect_btn.Name = "rconConnect_btn";
            this.rconConnect_btn.Size = new System.Drawing.Size(169, 31);
            this.rconConnect_btn.TabIndex = 8;
            this.rconConnect_btn.Text = "Подключить RCON";
            this.rconConnect_btn.UseVisualStyleBackColor = true;
            this.rconConnect_btn.Click += new System.EventHandler(this.rconConnect_btn_Click);
            // 
            // saveRconSettings_btn
            // 
            this.saveRconSettings_btn.ForeColor = System.Drawing.Color.Black;
            this.saveRconSettings_btn.Location = new System.Drawing.Point(12, 309);
            this.saveRconSettings_btn.Name = "saveRconSettings_btn";
            this.saveRconSettings_btn.Size = new System.Drawing.Size(169, 40);
            this.saveRconSettings_btn.TabIndex = 7;
            this.saveRconSettings_btn.Text = "Сохранить настройки";
            this.saveRconSettings_btn.UseVisualStyleBackColor = true;
            this.saveRconSettings_btn.Click += new System.EventHandler(this.saveRconSettings_btn_Click);
            // 
            // isServerAutoRestart_cb
            // 
            this.isServerAutoRestart_cb.AutoSize = true;
            this.isServerAutoRestart_cb.ForeColor = System.Drawing.Color.Black;
            this.isServerAutoRestart_cb.Location = new System.Drawing.Point(282, 52);
            this.isServerAutoRestart_cb.Name = "isServerAutoRestart_cb";
            this.isServerAutoRestart_cb.Size = new System.Drawing.Size(141, 17);
            this.isServerAutoRestart_cb.TabIndex = 1;
            this.isServerAutoRestart_cb.Text = "Включить авторестарт";
            this.isServerAutoRestart_cb.UseVisualStyleBackColor = true;
            // 
            // isSendRestartMsg_cb
            // 
            this.isSendRestartMsg_cb.AutoSize = true;
            this.isSendRestartMsg_cb.ForeColor = System.Drawing.Color.Black;
            this.isSendRestartMsg_cb.Location = new System.Drawing.Point(282, 75);
            this.isSendRestartMsg_cb.Name = "isSendRestartMsg_cb";
            this.isSendRestartMsg_cb.Size = new System.Drawing.Size(204, 17);
            this.isSendRestartMsg_cb.TabIndex = 2;
            this.isSendRestartMsg_cb.Text = "Отправлять сообщение о рестарте";
            this.isSendRestartMsg_cb.UseVisualStyleBackColor = true;
            // 
            // saveRestartSettings_bt
            // 
            this.saveRestartSettings_bt.ForeColor = System.Drawing.Color.Black;
            this.saveRestartSettings_bt.Location = new System.Drawing.Point(17, 291);
            this.saveRestartSettings_bt.Name = "saveRestartSettings_bt";
            this.saveRestartSettings_bt.Size = new System.Drawing.Size(153, 40);
            this.saveRestartSettings_bt.TabIndex = 7;
            this.saveRestartSettings_bt.Text = "Сохранить настройки";
            this.saveRestartSettings_bt.UseVisualStyleBackColor = true;
            this.saveRestartSettings_bt.Click += new System.EventHandler(this.saveRestartSettings_bt_Click);
            // 
            // serverAutoRestart_lbl
            // 
            this.serverAutoRestart_lbl.AutoSize = true;
            this.serverAutoRestart_lbl.ForeColor = System.Drawing.Color.Black;
            this.serverAutoRestart_lbl.Location = new System.Drawing.Point(14, 22);
            this.serverAutoRestart_lbl.Name = "serverAutoRestart_lbl";
            this.serverAutoRestart_lbl.Size = new System.Drawing.Size(174, 13);
            this.serverAutoRestart_lbl.TabIndex = 9;
            this.serverAutoRestart_lbl.Text = "Следующий рестарт через: 00:00";
            // 
            // changeServerStartFilePath_btn
            // 
            this.changeServerStartFilePath_btn.ForeColor = System.Drawing.Color.Black;
            this.changeServerStartFilePath_btn.Location = new System.Drawing.Point(156, 18);
            this.changeServerStartFilePath_btn.Name = "changeServerStartFilePath_btn";
            this.changeServerStartFilePath_btn.Size = new System.Drawing.Size(75, 23);
            this.changeServerStartFilePath_btn.TabIndex = 14;
            this.changeServerStartFilePath_btn.Text = "Изменить";
            this.changeServerStartFilePath_btn.UseVisualStyleBackColor = true;
            this.changeServerStartFilePath_btn.Click += new System.EventHandler(this.changeServerStartFilePath_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.isMakeBackup_cb);
            this.groupBox1.Controls.Add(this.serverRestart_btn);
            this.groupBox1.Controls.Add(this.serverStart_btn);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.serverAutoRestart_lbl);
            this.groupBox1.Controls.Add(this.saveRestartSettings_bt);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.isSendRestartMsg_cb);
            this.groupBox1.Controls.Add(this.isServerAutoRestart_cb);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(474, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 363);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сервер";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.changeServerBackupFolderPath_btn);
            this.groupBox11.Controls.Add(this.serverBackupFolderPath_tb);
            this.groupBox11.ForeColor = System.Drawing.Color.Black;
            this.groupBox11.Location = new System.Drawing.Point(17, 214);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(239, 48);
            this.groupBox11.TabIndex = 25;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Путь папки для бэкапов:";
            // 
            // changeServerBackupFolderPath_btn
            // 
            this.changeServerBackupFolderPath_btn.ForeColor = System.Drawing.Color.Black;
            this.changeServerBackupFolderPath_btn.Location = new System.Drawing.Point(156, 18);
            this.changeServerBackupFolderPath_btn.Name = "changeServerBackupFolderPath_btn";
            this.changeServerBackupFolderPath_btn.Size = new System.Drawing.Size(75, 23);
            this.changeServerBackupFolderPath_btn.TabIndex = 14;
            this.changeServerBackupFolderPath_btn.Text = "Изменить";
            this.changeServerBackupFolderPath_btn.UseVisualStyleBackColor = true;
            this.changeServerBackupFolderPath_btn.Click += new System.EventHandler(this.changeServerBackupFolderPath_btn_Click);
            // 
            // serverBackupFolderPath_tb
            // 
            this.serverBackupFolderPath_tb.Location = new System.Drawing.Point(6, 19);
            this.serverBackupFolderPath_tb.Name = "serverBackupFolderPath_tb";
            this.serverBackupFolderPath_tb.ReadOnly = true;
            this.serverBackupFolderPath_tb.Size = new System.Drawing.Size(133, 20);
            this.serverBackupFolderPath_tb.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.changeServerFolderPath_btn);
            this.groupBox10.Controls.Add(this.serverFolderPath_tb);
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(17, 160);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(239, 48);
            this.groupBox10.TabIndex = 24;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Путь к папке Zomboid:";
            // 
            // changeServerFolderPath_btn
            // 
            this.changeServerFolderPath_btn.ForeColor = System.Drawing.Color.Black;
            this.changeServerFolderPath_btn.Location = new System.Drawing.Point(156, 18);
            this.changeServerFolderPath_btn.Name = "changeServerFolderPath_btn";
            this.changeServerFolderPath_btn.Size = new System.Drawing.Size(75, 23);
            this.changeServerFolderPath_btn.TabIndex = 14;
            this.changeServerFolderPath_btn.Text = "Изменить";
            this.changeServerFolderPath_btn.UseVisualStyleBackColor = true;
            this.changeServerFolderPath_btn.Click += new System.EventHandler(this.changeServerFolderPath_btn_Click);
            // 
            // serverFolderPath_tb
            // 
            this.serverFolderPath_tb.Location = new System.Drawing.Point(6, 19);
            this.serverFolderPath_tb.Name = "serverFolderPath_tb";
            this.serverFolderPath_tb.ReadOnly = true;
            this.serverFolderPath_tb.Size = new System.Drawing.Size(133, 20);
            this.serverFolderPath_tb.TabIndex = 1;
            // 
            // isMakeBackup_cb
            // 
            this.isMakeBackup_cb.AutoSize = true;
            this.isMakeBackup_cb.ForeColor = System.Drawing.Color.Black;
            this.isMakeBackup_cb.Location = new System.Drawing.Point(282, 98);
            this.isMakeBackup_cb.Name = "isMakeBackup_cb";
            this.isMakeBackup_cb.Size = new System.Drawing.Size(200, 17);
            this.isMakeBackup_cb.TabIndex = 25;
            this.isMakeBackup_cb.Text = "Создать бэкап во время рестарта";
            this.isMakeBackup_cb.UseVisualStyleBackColor = true;
            // 
            // serverRestart_btn
            // 
            this.serverRestart_btn.Enabled = false;
            this.serverRestart_btn.Location = new System.Drawing.Point(333, 291);
            this.serverRestart_btn.Name = "serverRestart_btn";
            this.serverRestart_btn.Size = new System.Drawing.Size(153, 40);
            this.serverRestart_btn.TabIndex = 22;
            this.serverRestart_btn.Text = "Перезагрузить сервер";
            this.serverRestart_btn.UseVisualStyleBackColor = true;
            this.serverRestart_btn.Click += new System.EventHandler(this.serverRestart_btn_Click);
            // 
            // serverStart_btn
            // 
            this.serverStart_btn.ForeColor = System.Drawing.Color.Black;
            this.serverStart_btn.Location = new System.Drawing.Point(173, 291);
            this.serverStart_btn.Name = "serverStart_btn";
            this.serverStart_btn.Size = new System.Drawing.Size(153, 40);
            this.serverStart_btn.TabIndex = 24;
            this.serverStart_btn.Text = "Запустить сервер";
            this.serverStart_btn.UseVisualStyleBackColor = true;
            this.serverStart_btn.Click += new System.EventHandler(this.serverStart_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.changeServerStartFilePath_btn);
            this.groupBox2.Controls.Add(this.serverStartFilePath_tb);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(17, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 48);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Путь к стартовому файлу сервера:";
            // 
            // serverStartFilePath_tb
            // 
            this.serverStartFilePath_tb.Location = new System.Drawing.Point(6, 19);
            this.serverStartFilePath_tb.Name = "serverStartFilePath_tb";
            this.serverStartFilePath_tb.ReadOnly = true;
            this.serverStartFilePath_tb.Size = new System.Drawing.Size(133, 20);
            this.serverStartFilePath_tb.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.restartUtcTime_tb);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(17, 52);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 48);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Время рестарта HH:MM:SS (UTC):";
            // 
            // restartUtcTime_tb
            // 
            this.restartUtcTime_tb.Location = new System.Drawing.Point(6, 19);
            this.restartUtcTime_tb.Name = "restartUtcTime_tb";
            this.restartUtcTime_tb.Size = new System.Drawing.Size(133, 20);
            this.restartUtcTime_tb.TabIndex = 1;
            this.restartUtcTime_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.restartUtcTime_tb_KeyPress);
            // 
            // ChoiceServerStartFilePath
            // 
            this.ChoiceServerStartFilePath.FileName = "StartServerFile";
            this.ChoiceServerStartFilePath.Filter = "Bat files(*.bat)|*.bat|All files(*.*)|*.*";
            // 
            // EverySecond
            // 
            this.EverySecond.Interval = 1000;
            // 
            // EveryTenSeconds
            // 
            this.EveryTenSeconds.Interval = 10000;
            // 
            // RestartMessageTimer
            // 
            this.RestartMessageTimer.Interval = 60000;
            // 
            // ServerHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(985, 721);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ServerHelperForm";
            this.Text = "Помощник сервера";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label rconStatus_lbl;
        private System.Windows.Forms.Button rconSendCommand_btn;
        private System.Windows.Forms.Button rconConnect_btn;
        private System.Windows.Forms.Button saveRconSettings_btn;
        private System.Windows.Forms.CheckBox isServerAutoRestart_cb;
        private System.Windows.Forms.CheckBox isSendRestartMsg_cb;
        private System.Windows.Forms.Button saveRestartSettings_bt;
        private System.Windows.Forms.Label serverAutoRestart_lbl;
        private System.Windows.Forms.Button changeServerStartFilePath_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox restartUtcTime_tb;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox rconSendCommand_tb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox serverResponce_rtb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox serverStartFilePath_tb;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox serverIP_tb;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox rconPort_tb;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox rconPassword_tb;
        private System.Windows.Forms.CheckBox isRconAutoRestart_cb;
        private System.Windows.Forms.OpenFileDialog ChoiceServerStartFilePath;
        private System.Windows.Forms.Timer EverySecond;
        private System.Windows.Forms.Timer EveryTenSeconds;
        private System.Windows.Forms.Timer RestartMessageTimer;
        private System.Windows.Forms.Button serverStart_btn;
        private System.Windows.Forms.Button serverRestart_btn;
        private System.Windows.Forms.CheckBox isMakeBackup_cb;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button changeServerFolderPath_btn;
        private System.Windows.Forms.TextBox serverFolderPath_tb;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button changeServerBackupFolderPath_btn;
        private System.Windows.Forms.TextBox serverBackupFolderPath_tb;
        private System.Windows.Forms.FolderBrowserDialog ChoiceServerFolderPath;
        private System.Windows.Forms.FolderBrowserDialog ChoiceServerBackupFolderPath;
    }
}