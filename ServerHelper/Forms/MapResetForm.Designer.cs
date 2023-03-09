namespace ServerHelper.Forms
{
    partial class MapResetForm
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
            this.mapX_lbl = new System.Windows.Forms.Label();
            this.mapY_lbl = new System.Windows.Forms.Label();
            this.scale_lbl = new System.Windows.Forms.Label();
            this.mapStatus_lbl = new System.Windows.Forms.Label();
            this.PZMap_pb = new System.Windows.Forms.PictureBox();
            this.loadMap_btn = new System.Windows.Forms.Button();
            this.clearAllZones_btn = new System.Windows.Forms.Button();
            this.mapResetSettings_btn = new System.Windows.Forms.Button();
            this.zones_lv = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartCoordinate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndCoordinate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p1Y_tb = new System.Windows.Forms.TextBox();
            this.p1X_tb = new System.Windows.Forms.TextBox();
            this.addZoneFromCoord_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p2X_tb = new System.Windows.Forms.TextBox();
            this.p2Y_tb = new System.Windows.Forms.TextBox();
            this.clearSelectZones_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectTypeAddZone_cb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectDrawTypeZone_cb = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.selectTypeImpExpZone_cb = new System.Windows.Forms.ComboBox();
            this.importZones_btn = new System.Windows.Forms.Button();
            this.exportZones_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mapСalibration_btn = new System.Windows.Forms.Button();
            this.ChoiceExportZonesFilePath = new System.Windows.Forms.SaveFileDialog();
            this.ChoiceImportZonesFilePath = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PZMap_pb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapX_lbl
            // 
            this.mapX_lbl.AutoSize = true;
            this.mapX_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapX_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mapX_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapX_lbl.Location = new System.Drawing.Point(5, 43);
            this.mapX_lbl.Name = "mapX_lbl";
            this.mapX_lbl.Size = new System.Drawing.Size(75, 13);
            this.mapX_lbl.TabIndex = 1;
            this.mapX_lbl.Text = "X Coord: 1000";
            // 
            // mapY_lbl
            // 
            this.mapY_lbl.AutoSize = true;
            this.mapY_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapY_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mapY_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapY_lbl.Location = new System.Drawing.Point(102, 43);
            this.mapY_lbl.Name = "mapY_lbl";
            this.mapY_lbl.Size = new System.Drawing.Size(75, 13);
            this.mapY_lbl.TabIndex = 2;
            this.mapY_lbl.Text = "Y Coord: 1000";
            // 
            // scale_lbl
            // 
            this.scale_lbl.AutoSize = true;
            this.scale_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scale_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scale_lbl.Location = new System.Drawing.Point(198, 43);
            this.scale_lbl.Name = "scale_lbl";
            this.scale_lbl.Size = new System.Drawing.Size(51, 13);
            this.scale_lbl.TabIndex = 6;
            this.scale_lbl.Text = "Scale: x1";
            // 
            // mapStatus_lbl
            // 
            this.mapStatus_lbl.AutoSize = true;
            this.mapStatus_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapStatus_lbl.ForeColor = System.Drawing.Color.Green;
            this.mapStatus_lbl.Location = new System.Drawing.Point(6, 19);
            this.mapStatus_lbl.Name = "mapStatus_lbl";
            this.mapStatus_lbl.Size = new System.Drawing.Size(202, 13);
            this.mapStatus_lbl.TabIndex = 12;
            this.mapStatus_lbl.Text = "Карта отключена. Ресурсы не заняты.";
            // 
            // PZMap_pb
            // 
            this.PZMap_pb.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PZMap_pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PZMap_pb.Location = new System.Drawing.Point(0, 0);
            this.PZMap_pb.Name = "PZMap_pb";
            this.PZMap_pb.Size = new System.Drawing.Size(857, 588);
            this.PZMap_pb.TabIndex = 13;
            this.PZMap_pb.TabStop = false;
            this.PZMap_pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_pb_MouseDown);
            this.PZMap_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_pb_MouseMove);
            this.PZMap_pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_pb_MouseUp);
            // 
            // loadMap_btn
            // 
            this.loadMap_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadMap_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadMap_btn.ForeColor = System.Drawing.Color.Black;
            this.loadMap_btn.Location = new System.Drawing.Point(712, 20);
            this.loadMap_btn.Name = "loadMap_btn";
            this.loadMap_btn.Size = new System.Drawing.Size(124, 39);
            this.loadMap_btn.TabIndex = 10;
            this.loadMap_btn.Text = "Включить карту";
            this.loadMap_btn.UseVisualStyleBackColor = true;
            this.loadMap_btn.Click += new System.EventHandler(this.loadMap_btn_Click);
            // 
            // clearAllZones_btn
            // 
            this.clearAllZones_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearAllZones_btn.ForeColor = System.Drawing.Color.Black;
            this.clearAllZones_btn.Location = new System.Drawing.Point(8, 368);
            this.clearAllZones_btn.Name = "clearAllZones_btn";
            this.clearAllZones_btn.Size = new System.Drawing.Size(125, 30);
            this.clearAllZones_btn.TabIndex = 14;
            this.clearAllZones_btn.Text = "Очистить все зоны";
            this.clearAllZones_btn.UseVisualStyleBackColor = true;
            this.clearAllZones_btn.Click += new System.EventHandler(this.clearAllRect_btn_Click);
            // 
            // mapResetSettings_btn
            // 
            this.mapResetSettings_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mapResetSettings_btn.ForeColor = System.Drawing.Color.Black;
            this.mapResetSettings_btn.Location = new System.Drawing.Point(582, 20);
            this.mapResetSettings_btn.Name = "mapResetSettings_btn";
            this.mapResetSettings_btn.Size = new System.Drawing.Size(124, 39);
            this.mapResetSettings_btn.TabIndex = 16;
            this.mapResetSettings_btn.Text = "Меню сброса";
            this.mapResetSettings_btn.UseVisualStyleBackColor = true;
            this.mapResetSettings_btn.Click += new System.EventHandler(this.mapResetSettings_btn_Click);
            // 
            // zones_lv
            // 
            this.zones_lv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.zones_lv.BackColor = System.Drawing.SystemColors.Window;
            this.zones_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Type,
            this.StartCoordinate,
            this.EndCoordinate});
            this.zones_lv.FullRowSelect = true;
            this.zones_lv.GridLines = true;
            this.zones_lv.HideSelection = false;
            this.zones_lv.Location = new System.Drawing.Point(8, 62);
            this.zones_lv.Name = "zones_lv";
            this.zones_lv.Size = new System.Drawing.Size(258, 300);
            this.zones_lv.TabIndex = 18;
            this.zones_lv.UseCompatibleStateImageBehavior = false;
            this.zones_lv.View = System.Windows.Forms.View.Details;
            this.zones_lv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.rectangles_lv_ItemSelectionChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 32;
            // 
            // Type
            // 
            this.Type.Text = "Тип";
            this.Type.Width = 41;
            // 
            // StartCoordinate
            // 
            this.StartCoordinate.Text = "Л. верх. точка";
            this.StartCoordinate.Width = 91;
            // 
            // EndCoordinate
            // 
            this.EndCoordinate.Text = "П. ниж. точка";
            this.EndCoordinate.Width = 82;
            // 
            // p1Y_tb
            // 
            this.p1Y_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p1Y_tb.Location = new System.Drawing.Point(101, 20);
            this.p1Y_tb.Name = "p1Y_tb";
            this.p1Y_tb.Size = new System.Drawing.Size(54, 20);
            this.p1Y_tb.TabIndex = 23;
            this.p1Y_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // p1X_tb
            // 
            this.p1X_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p1X_tb.Location = new System.Drawing.Point(24, 20);
            this.p1X_tb.Name = "p1X_tb";
            this.p1X_tb.Size = new System.Drawing.Size(54, 20);
            this.p1X_tb.TabIndex = 24;
            this.p1X_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // addZoneFromCoord_btn
            // 
            this.addZoneFromCoord_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addZoneFromCoord_btn.ForeColor = System.Drawing.Color.Black;
            this.addZoneFromCoord_btn.Location = new System.Drawing.Point(161, 46);
            this.addZoneFromCoord_btn.Name = "addZoneFromCoord_btn";
            this.addZoneFromCoord_btn.Size = new System.Drawing.Size(105, 23);
            this.addZoneFromCoord_btn.TabIndex = 27;
            this.addZoneFromCoord_btn.Text = "Добавить";
            this.addZoneFromCoord_btn.UseVisualStyleBackColor = true;
            this.addZoneFromCoord_btn.Click += new System.EventHandler(this.addZoneFromCoord_btn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "X";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(84, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(84, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "X";
            // 
            // p2X_tb
            // 
            this.p2X_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p2X_tb.Location = new System.Drawing.Point(24, 49);
            this.p2X_tb.Name = "p2X_tb";
            this.p2X_tb.Size = new System.Drawing.Size(54, 20);
            this.p2X_tb.TabIndex = 37;
            this.p2X_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // p2Y_tb
            // 
            this.p2Y_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p2Y_tb.Location = new System.Drawing.Point(101, 49);
            this.p2Y_tb.Name = "p2Y_tb";
            this.p2Y_tb.Size = new System.Drawing.Size(54, 20);
            this.p2Y_tb.TabIndex = 36;
            this.p2Y_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // clearSelectZones_btn
            // 
            this.clearSelectZones_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearSelectZones_btn.ForeColor = System.Drawing.Color.Black;
            this.clearSelectZones_btn.Location = new System.Drawing.Point(139, 368);
            this.clearSelectZones_btn.Name = "clearSelectZones_btn";
            this.clearSelectZones_btn.Size = new System.Drawing.Size(127, 30);
            this.clearSelectZones_btn.TabIndex = 40;
            this.clearSelectZones_btn.Text = "Удалить выбранные";
            this.clearSelectZones_btn.UseVisualStyleBackColor = true;
            this.clearSelectZones_btn.Click += new System.EventHandler(this.clearSelectRect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.selectTypeAddZone_cb);
            this.groupBox1.Controls.Add(this.p1X_tb);
            this.groupBox1.Controls.Add(this.p1Y_tb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addZoneFromCoord_btn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.p2X_tb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.p2Y_tb);
            this.groupBox1.Location = new System.Drawing.Point(3, 491);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 80);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить зону по коорд. (две любые точки):";
            // 
            // selectTypeAddZone_cb
            // 
            this.selectTypeAddZone_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTypeAddZone_cb.FormattingEnabled = true;
            this.selectTypeAddZone_cb.Location = new System.Drawing.Point(161, 19);
            this.selectTypeAddZone_cb.Name = "selectTypeAddZone_cb";
            this.selectTypeAddZone_cb.Size = new System.Drawing.Size(105, 21);
            this.selectTypeAddZone_cb.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.selectDrawTypeZone_cb);
            this.groupBox2.Controls.Add(this.clearAllZones_btn);
            this.groupBox2.Controls.Add(this.clearSelectZones_btn);
            this.groupBox2.Controls.Add(this.zones_lv);
            this.groupBox2.Location = new System.Drawing.Point(3, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 410);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список всех зон:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Тип выделяемой зоны:";
            // 
            // selectDrawTypeZone_cb
            // 
            this.selectDrawTypeZone_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDrawTypeZone_cb.FormattingEnabled = true;
            this.selectDrawTypeZone_cb.Location = new System.Drawing.Point(8, 35);
            this.selectDrawTypeZone_cb.Name = "selectDrawTypeZone_cb";
            this.selectDrawTypeZone_cb.Size = new System.Drawing.Size(123, 21);
            this.selectDrawTypeZone_cb.TabIndex = 45;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mapStatus_lbl);
            this.groupBox3.Controls.Add(this.mapX_lbl);
            this.groupBox3.Controls.Add(this.mapY_lbl);
            this.groupBox3.Controls.Add(this.scale_lbl);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 66);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 671);
            this.panel1.TabIndex = 44;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.selectTypeImpExpZone_cb);
            this.groupBox8.Controls.Add(this.importZones_btn);
            this.groupBox8.Controls.Add(this.exportZones_btn);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(3, 577);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(272, 85);
            this.groupBox8.TabIndex = 43;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Импорт/экспорт зон:";
            // 
            // selectTypeImpExpZone_cb
            // 
            this.selectTypeImpExpZone_cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectTypeImpExpZone_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTypeImpExpZone_cb.FormattingEnabled = true;
            this.selectTypeImpExpZone_cb.Location = new System.Drawing.Point(6, 19);
            this.selectTypeImpExpZone_cb.Name = "selectTypeImpExpZone_cb";
            this.selectTypeImpExpZone_cb.Size = new System.Drawing.Size(260, 21);
            this.selectTypeImpExpZone_cb.TabIndex = 40;
            // 
            // importZones_btn
            // 
            this.importZones_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importZones_btn.ForeColor = System.Drawing.Color.Black;
            this.importZones_btn.Location = new System.Drawing.Point(6, 46);
            this.importZones_btn.Name = "importZones_btn";
            this.importZones_btn.Size = new System.Drawing.Size(125, 29);
            this.importZones_btn.TabIndex = 41;
            this.importZones_btn.Text = "Импорт";
            this.importZones_btn.UseVisualStyleBackColor = true;
            this.importZones_btn.Click += new System.EventHandler(this.importZones_btn_Click);
            // 
            // exportZones_btn
            // 
            this.exportZones_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportZones_btn.ForeColor = System.Drawing.Color.Black;
            this.exportZones_btn.Location = new System.Drawing.Point(141, 46);
            this.exportZones_btn.Name = "exportZones_btn";
            this.exportZones_btn.Size = new System.Drawing.Size(125, 29);
            this.exportZones_btn.TabIndex = 42;
            this.exportZones_btn.Text = "Экспорт";
            this.exportZones_btn.UseVisualStyleBackColor = true;
            this.exportZones_btn.Click += new System.EventHandler(this.exportZones_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PZMap_pb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(281, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 588);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(281, 588);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 83);
            this.panel3.TabIndex = 46;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.mapСalibration_btn);
            this.groupBox4.Controls.Add(this.mapResetSettings_btn);
            this.groupBox4.Controls.Add(this.loadMap_btn);
            this.groupBox4.Location = new System.Drawing.Point(7, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(842, 71);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Управление:";
            // 
            // mapСalibration_btn
            // 
            this.mapСalibration_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mapСalibration_btn.ForeColor = System.Drawing.Color.Black;
            this.mapСalibration_btn.Location = new System.Drawing.Point(6, 19);
            this.mapСalibration_btn.Name = "mapСalibration_btn";
            this.mapСalibration_btn.Size = new System.Drawing.Size(148, 40);
            this.mapСalibration_btn.TabIndex = 44;
            this.mapСalibration_btn.Text = "Калибровка карты / настройки";
            this.mapСalibration_btn.UseVisualStyleBackColor = true;
            this.mapСalibration_btn.Click += new System.EventHandler(this.mapСalibration_btn_Click);
            // 
            // ChoiceExportZonesFilePath
            // 
            this.ChoiceExportZonesFilePath.DefaultExt = "zones";
            this.ChoiceExportZonesFilePath.FileName = "MyZones";
            this.ChoiceExportZonesFilePath.Filter = "Zones files(*.zones)|*.zones|All files(*.*)|*.*";
            // 
            // ChoiceImportZonesFilePath
            // 
            this.ChoiceImportZonesFilePath.FileName = "Zones";
            this.ChoiceImportZonesFilePath.Filter = "Zones files(*.zones)|*.zones|All files(*.*)|*.*";
            // 
            // MapResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 671);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MapResetForm";
            this.Text = "Сброс карты";
            this.Resize += new System.EventHandler(this.MapResetForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PZMap_pb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label mapX_lbl;
        private System.Windows.Forms.Label mapY_lbl;
        private System.Windows.Forms.Label scale_lbl;
        private System.Windows.Forms.Label mapStatus_lbl;
        private System.Windows.Forms.PictureBox PZMap_pb;
        private System.Windows.Forms.Button loadMap_btn;
        private System.Windows.Forms.Button clearAllZones_btn;
        private System.Windows.Forms.Button mapResetSettings_btn;
        private System.Windows.Forms.ListView zones_lv;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader StartCoordinate;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader EndCoordinate;
        private System.Windows.Forms.TextBox p1Y_tb;
        private System.Windows.Forms.TextBox p1X_tb;
        private System.Windows.Forms.Button addZoneFromCoord_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox p2X_tb;
        private System.Windows.Forms.TextBox p2Y_tb;
        private System.Windows.Forms.Button clearSelectZones_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox selectTypeAddZone_cb;
        private System.Windows.Forms.Button mapСalibration_btn;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox selectTypeImpExpZone_cb;
        private System.Windows.Forms.Button importZones_btn;
        private System.Windows.Forms.Button exportZones_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox selectDrawTypeZone_cb;
        private System.Windows.Forms.SaveFileDialog ChoiceExportZonesFilePath;
        private System.Windows.Forms.OpenFileDialog ChoiceImportZonesFilePath;
    }
}