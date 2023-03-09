namespace ServerHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.applicationSettings_btn = new System.Windows.Forms.Button();
            this.mapResetTool_btn = new System.Windows.Forms.Button();
            this.serverHelper_btn = new System.Windows.Forms.Button();
            this.discord_btn = new System.Windows.Forms.Button();
            this.logoBar_pnl = new System.Windows.Forms.Panel();
            this.rconStatus_pb = new System.Windows.Forms.PictureBox();
            this.botStatus_pb = new System.Windows.Forms.PictureBox();
            this.logoBar_lbl = new System.Windows.Forms.Label();
            this.logoBar_btn = new System.Windows.Forms.Button();
            this.titleBar_pnl = new System.Windows.Forms.Panel();
            this.appMinimize_btn = new System.Windows.Forms.Button();
            this.appClose_btn = new System.Windows.Forms.Button();
            this.backHome_btn = new System.Windows.Forms.Button();
            this.utcTime_lbl = new System.Windows.Forms.Label();
            this.Title_lbl = new System.Windows.Forms.Label();
            this.desktopPanel_pnl = new System.Windows.Forms.Panel();
            this.EverySecond = new System.Windows.Forms.Timer(this.components);
            this.mapReset_pb = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.logoBar_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rconStatus_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botStatus_pb)).BeginInit();
            this.titleBar_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapReset_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.applicationSettings_btn);
            this.panelMenu.Controls.Add(this.mapResetTool_btn);
            this.panelMenu.Controls.Add(this.serverHelper_btn);
            this.panelMenu.Controls.Add(this.discord_btn);
            this.panelMenu.Controls.Add(this.logoBar_pnl);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 721);
            this.panelMenu.TabIndex = 0;
            // 
            // applicationSettings_btn
            // 
            this.applicationSettings_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.applicationSettings_btn.FlatAppearance.BorderSize = 0;
            this.applicationSettings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applicationSettings_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.applicationSettings_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.applicationSettings_btn.Location = new System.Drawing.Point(0, 275);
            this.applicationSettings_btn.Name = "applicationSettings_btn";
            this.applicationSettings_btn.Size = new System.Drawing.Size(200, 65);
            this.applicationSettings_btn.TabIndex = 5;
            this.applicationSettings_btn.Text = "Настройки приложения";
            this.applicationSettings_btn.UseVisualStyleBackColor = true;
            this.applicationSettings_btn.Click += new System.EventHandler(this.applicationSettings_btn_Click);
            // 
            // mapResetTool_btn
            // 
            this.mapResetTool_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.mapResetTool_btn.FlatAppearance.BorderSize = 0;
            this.mapResetTool_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapResetTool_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mapResetTool_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.mapResetTool_btn.Location = new System.Drawing.Point(0, 210);
            this.mapResetTool_btn.Name = "mapResetTool_btn";
            this.mapResetTool_btn.Size = new System.Drawing.Size(200, 65);
            this.mapResetTool_btn.TabIndex = 4;
            this.mapResetTool_btn.Text = "Сброс карты";
            this.mapResetTool_btn.UseVisualStyleBackColor = true;
            this.mapResetTool_btn.Click += new System.EventHandler(this.mapResetTool_btn_Click);
            // 
            // serverHelper_btn
            // 
            this.serverHelper_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.serverHelper_btn.FlatAppearance.BorderSize = 0;
            this.serverHelper_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serverHelper_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.serverHelper_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.serverHelper_btn.Location = new System.Drawing.Point(0, 145);
            this.serverHelper_btn.Name = "serverHelper_btn";
            this.serverHelper_btn.Size = new System.Drawing.Size(200, 65);
            this.serverHelper_btn.TabIndex = 2;
            this.serverHelper_btn.Text = "Помощник сервера";
            this.serverHelper_btn.UseVisualStyleBackColor = true;
            this.serverHelper_btn.Click += new System.EventHandler(this.serverHelper_btn_Click);
            // 
            // discord_btn
            // 
            this.discord_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.discord_btn.FlatAppearance.BorderSize = 0;
            this.discord_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discord_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.discord_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.discord_btn.Location = new System.Drawing.Point(0, 80);
            this.discord_btn.Name = "discord_btn";
            this.discord_btn.Size = new System.Drawing.Size(200, 65);
            this.discord_btn.TabIndex = 1;
            this.discord_btn.Text = "Дискорд бот";
            this.discord_btn.UseVisualStyleBackColor = true;
            this.discord_btn.Click += new System.EventHandler(this.discord_btn_Click);
            // 
            // logoBar_pnl
            // 
            this.logoBar_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(50)))));
            this.logoBar_pnl.Controls.Add(this.mapReset_pb);
            this.logoBar_pnl.Controls.Add(this.rconStatus_pb);
            this.logoBar_pnl.Controls.Add(this.botStatus_pb);
            this.logoBar_pnl.Controls.Add(this.logoBar_lbl);
            this.logoBar_pnl.Controls.Add(this.logoBar_btn);
            this.logoBar_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoBar_pnl.Location = new System.Drawing.Point(0, 0);
            this.logoBar_pnl.Name = "logoBar_pnl";
            this.logoBar_pnl.Size = new System.Drawing.Size(200, 80);
            this.logoBar_pnl.TabIndex = 0;
            this.logoBar_pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoBar_pnl_MouseDown);
            // 
            // rconStatus_pb
            // 
            this.rconStatus_pb.Image = ((System.Drawing.Image)(resources.GetObject("rconStatus_pb.Image")));
            this.rconStatus_pb.Location = new System.Drawing.Point(3, 0);
            this.rconStatus_pb.Name = "rconStatus_pb";
            this.rconStatus_pb.Size = new System.Drawing.Size(33, 28);
            this.rconStatus_pb.TabIndex = 6;
            this.rconStatus_pb.TabStop = false;
            // 
            // botStatus_pb
            // 
            this.botStatus_pb.Image = ((System.Drawing.Image)(resources.GetObject("botStatus_pb.Image")));
            this.botStatus_pb.Location = new System.Drawing.Point(43, 0);
            this.botStatus_pb.Name = "botStatus_pb";
            this.botStatus_pb.Size = new System.Drawing.Size(29, 29);
            this.botStatus_pb.TabIndex = 5;
            this.botStatus_pb.TabStop = false;
            // 
            // logoBar_lbl
            // 
            this.logoBar_lbl.AutoSize = true;
            this.logoBar_lbl.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoBar_lbl.ForeColor = System.Drawing.Color.White;
            this.logoBar_lbl.Location = new System.Drawing.Point(28, 29);
            this.logoBar_lbl.Name = "logoBar_lbl";
            this.logoBar_lbl.Size = new System.Drawing.Size(145, 27);
            this.logoBar_lbl.TabIndex = 1;
            this.logoBar_lbl.Text = "Server Helper";
            this.logoBar_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.logoBar_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoBar_lbl_MouseDown);
            // 
            // logoBar_btn
            // 
            this.logoBar_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoBar_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoBar_btn.FlatAppearance.BorderSize = 0;
            this.logoBar_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoBar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoBar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoBar_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoBar_btn.Location = new System.Drawing.Point(0, 59);
            this.logoBar_btn.Name = "logoBar_btn";
            this.logoBar_btn.Size = new System.Drawing.Size(200, 21);
            this.logoBar_btn.TabIndex = 0;
            this.logoBar_btn.UseVisualStyleBackColor = true;
            this.logoBar_btn.Click += new System.EventHandler(this.logoBar_btn_Click);
            // 
            // titleBar_pnl
            // 
            this.titleBar_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.titleBar_pnl.Controls.Add(this.appMinimize_btn);
            this.titleBar_pnl.Controls.Add(this.appClose_btn);
            this.titleBar_pnl.Controls.Add(this.backHome_btn);
            this.titleBar_pnl.Controls.Add(this.utcTime_lbl);
            this.titleBar_pnl.Controls.Add(this.Title_lbl);
            this.titleBar_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar_pnl.Location = new System.Drawing.Point(200, 0);
            this.titleBar_pnl.Name = "titleBar_pnl";
            this.titleBar_pnl.Size = new System.Drawing.Size(1084, 79);
            this.titleBar_pnl.TabIndex = 1;
            this.titleBar_pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_pnl_MouseDown);
            // 
            // appMinimize_btn
            // 
            this.appMinimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.appMinimize_btn.FlatAppearance.BorderSize = 0;
            this.appMinimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appMinimize_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appMinimize_btn.ForeColor = System.Drawing.Color.White;
            this.appMinimize_btn.Location = new System.Drawing.Point(998, 0);
            this.appMinimize_btn.Name = "appMinimize_btn";
            this.appMinimize_btn.Size = new System.Drawing.Size(43, 79);
            this.appMinimize_btn.TabIndex = 7;
            this.appMinimize_btn.Text = "O";
            this.appMinimize_btn.UseVisualStyleBackColor = true;
            this.appMinimize_btn.Click += new System.EventHandler(this.appMinimize_btn_Click);
            // 
            // appClose_btn
            // 
            this.appClose_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.appClose_btn.FlatAppearance.BorderSize = 0;
            this.appClose_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appClose_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appClose_btn.ForeColor = System.Drawing.Color.White;
            this.appClose_btn.Location = new System.Drawing.Point(1041, 0);
            this.appClose_btn.Name = "appClose_btn";
            this.appClose_btn.Size = new System.Drawing.Size(43, 79);
            this.appClose_btn.TabIndex = 6;
            this.appClose_btn.Text = "X";
            this.appClose_btn.UseVisualStyleBackColor = true;
            this.appClose_btn.Click += new System.EventHandler(this.appClose_btn_Click);
            // 
            // backHome_btn
            // 
            this.backHome_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.backHome_btn.FlatAppearance.BorderSize = 0;
            this.backHome_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backHome_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backHome_btn.ForeColor = System.Drawing.Color.White;
            this.backHome_btn.Location = new System.Drawing.Point(0, 0);
            this.backHome_btn.Name = "backHome_btn";
            this.backHome_btn.Size = new System.Drawing.Size(48, 79);
            this.backHome_btn.TabIndex = 5;
            this.backHome_btn.Text = "←";
            this.backHome_btn.UseVisualStyleBackColor = true;
            this.backHome_btn.Click += new System.EventHandler(this.backHome_btn_Click);
            // 
            // utcTime_lbl
            // 
            this.utcTime_lbl.AutoSize = true;
            this.utcTime_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.utcTime_lbl.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.utcTime_lbl.ForeColor = System.Drawing.Color.White;
            this.utcTime_lbl.Location = new System.Drawing.Point(538, 24);
            this.utcTime_lbl.Name = "utcTime_lbl";
            this.utcTime_lbl.Size = new System.Drawing.Size(391, 40);
            this.utcTime_lbl.TabIndex = 4;
            this.utcTime_lbl.Text = "00.00.0000 00:00:00 UTC";
            this.utcTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.utcTime_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.utcTime_lbl_MouseDown);
            // 
            // Title_lbl
            // 
            this.Title_lbl.AutoSize = true;
            this.Title_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Title_lbl.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title_lbl.ForeColor = System.Drawing.Color.White;
            this.Title_lbl.Location = new System.Drawing.Point(54, 11);
            this.Title_lbl.Name = "Title_lbl";
            this.Title_lbl.Size = new System.Drawing.Size(185, 55);
            this.Title_lbl.TabIndex = 0;
            this.Title_lbl.Text = "Главная";
            this.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_lbl_MouseDown);
            // 
            // desktopPanel_pnl
            // 
            this.desktopPanel_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopPanel_pnl.ForeColor = System.Drawing.Color.White;
            this.desktopPanel_pnl.Location = new System.Drawing.Point(200, 79);
            this.desktopPanel_pnl.Name = "desktopPanel_pnl";
            this.desktopPanel_pnl.Size = new System.Drawing.Size(1084, 642);
            this.desktopPanel_pnl.TabIndex = 2;
            // 
            // EverySecond
            // 
            this.EverySecond.Interval = 1000;
            // 
            // mapReset_pb
            // 
            this.mapReset_pb.Image = global::ServerHelper.Properties.Resources.resetMapOff;
            this.mapReset_pb.Location = new System.Drawing.Point(170, 1);
            this.mapReset_pb.Name = "mapReset_pb";
            this.mapReset_pb.Size = new System.Drawing.Size(29, 29);
            this.mapReset_pb.TabIndex = 7;
            this.mapReset_pb.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 721);
            this.Controls.Add(this.desktopPanel_pnl);
            this.Controls.Add(this.titleBar_pnl);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1500, 900);
            this.MinimumSize = new System.Drawing.Size(1300, 760);
            this.Name = "MainForm";
            this.Text = "Помощник сервера";
            this.panelMenu.ResumeLayout(false);
            this.logoBar_pnl.ResumeLayout(false);
            this.logoBar_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rconStatus_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botStatus_pb)).EndInit();
            this.titleBar_pnl.ResumeLayout(false);
            this.titleBar_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapReset_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button serverHelper_btn;
        private System.Windows.Forms.Button discord_btn;
        private System.Windows.Forms.Panel logoBar_pnl;
        private System.Windows.Forms.Panel titleBar_pnl;
        private System.Windows.Forms.Label Title_lbl;
        private System.Windows.Forms.Panel desktopPanel_pnl;
        private System.Windows.Forms.Button logoBar_btn;
        private System.Windows.Forms.Label logoBar_lbl;
        private System.Windows.Forms.Label utcTime_lbl;
        private System.Windows.Forms.Timer EverySecond;
        private System.Windows.Forms.Button backHome_btn;
        private System.Windows.Forms.Button appClose_btn;
        private System.Windows.Forms.Button appMinimize_btn;
        private System.Windows.Forms.PictureBox botStatus_pb;
        private System.Windows.Forms.PictureBox rconStatus_pb;
        private System.Windows.Forms.Button applicationSettings_btn;
        private System.Windows.Forms.Button mapResetTool_btn;
        private System.Windows.Forms.PictureBox mapReset_pb;
    }
}

