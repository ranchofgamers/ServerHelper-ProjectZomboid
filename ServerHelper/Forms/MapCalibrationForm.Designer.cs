namespace ServerHelper.Forms
{
    partial class MapCalibrationForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.refRBY_tb = new System.Windows.Forms.TextBox();
            this.refRBX_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.refLBY_tb = new System.Windows.Forms.TextBox();
            this.refLBX_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.refRTY_tb = new System.Windows.Forms.TextBox();
            this.refRTX_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.refLTY_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refLTX_tb = new System.Windows.Forms.TextBox();
            this.mapX_lbl = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.changeMapFile_btn = new System.Windows.Forms.Button();
            this.mapFilePath_tb = new System.Windows.Forms.TextBox();
            this.resertToDefaultMap_btn = new System.Windows.Forms.Button();
            this.saveSettings_btn = new System.Windows.Forms.Button();
            this.SelectMapFilePath = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeMapFolderPath_btn = new System.Windows.Forms.Button();
            this.mapFolderPath_tb = new System.Windows.Forms.TextBox();
            this.ChoiceMapFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.refRBY_tb);
            this.groupBox3.Controls.Add(this.refRBX_tb);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.refLBY_tb);
            this.groupBox3.Controls.Add(this.refLBX_tb);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.refRTY_tb);
            this.groupBox3.Controls.Add(this.refRTX_tb);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.refLTY_tb);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.refLTX_tb);
            this.groupBox3.Controls.Add(this.mapX_lbl);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 106);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Координаты в игровом мире:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(232, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "x";
            // 
            // refRBY_tb
            // 
            this.refRBY_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refRBY_tb.Location = new System.Drawing.Point(250, 78);
            this.refRBY_tb.Name = "refRBY_tb";
            this.refRBY_tb.Size = new System.Drawing.Size(41, 20);
            this.refRBY_tb.TabIndex = 42;
            this.refRBY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // refRBX_tb
            // 
            this.refRBX_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refRBX_tb.Location = new System.Drawing.Point(184, 78);
            this.refRBX_tb.Name = "refRBX_tb";
            this.refRBX_tb.Size = new System.Drawing.Size(41, 20);
            this.refRBX_tb.TabIndex = 41;
            this.refRBX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(59, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "x";
            // 
            // refLBY_tb
            // 
            this.refLBY_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refLBY_tb.Location = new System.Drawing.Point(77, 80);
            this.refLBY_tb.Name = "refLBY_tb";
            this.refLBY_tb.Size = new System.Drawing.Size(41, 20);
            this.refLBY_tb.TabIndex = 39;
            this.refLBY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // refLBX_tb
            // 
            this.refLBX_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refLBX_tb.Location = new System.Drawing.Point(11, 80);
            this.refLBX_tb.Name = "refLBX_tb";
            this.refLBX_tb.Size = new System.Drawing.Size(41, 20);
            this.refLBX_tb.TabIndex = 38;
            this.refLBX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(232, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "x";
            // 
            // refRTY_tb
            // 
            this.refRTY_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refRTY_tb.Location = new System.Drawing.Point(250, 36);
            this.refRTY_tb.Name = "refRTY_tb";
            this.refRTY_tb.Size = new System.Drawing.Size(41, 20);
            this.refRTY_tb.TabIndex = 36;
            this.refRTY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // refRTX_tb
            // 
            this.refRTX_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refRTX_tb.Location = new System.Drawing.Point(184, 36);
            this.refRTX_tb.Name = "refRTX_tb";
            this.refRTX_tb.Size = new System.Drawing.Size(41, 20);
            this.refRTX_tb.TabIndex = 35;
            this.refRTX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(59, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "x";
            // 
            // refLTY_tb
            // 
            this.refLTY_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refLTY_tb.Location = new System.Drawing.Point(77, 36);
            this.refLTY_tb.Name = "refLTY_tb";
            this.refLTY_tb.Size = new System.Drawing.Size(41, 20);
            this.refLTY_tb.TabIndex = 33;
            this.refLTY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(181, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Правый нижний угол:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Левый нижний угол:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(181, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Правый верхний угол:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Левый верхний угол:";
            // 
            // refLTX_tb
            // 
            this.refLTX_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refLTX_tb.Location = new System.Drawing.Point(11, 36);
            this.refLTX_tb.Name = "refLTX_tb";
            this.refLTX_tb.Size = new System.Drawing.Size(41, 20);
            this.refLTX_tb.TabIndex = 25;
            this.refLTX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordsTB_KeyPress);
            // 
            // mapX_lbl
            // 
            this.mapX_lbl.AutoSize = true;
            this.mapX_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapX_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mapX_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapX_lbl.Location = new System.Drawing.Point(5, 43);
            this.mapX_lbl.Name = "mapX_lbl";
            this.mapX_lbl.Size = new System.Drawing.Size(0, 13);
            this.mapX_lbl.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.changeMapFile_btn);
            this.groupBox10.Controls.Add(this.mapFilePath_tb);
            this.groupBox10.Controls.Add(this.resertToDefaultMap_btn);
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(12, 124);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(302, 82);
            this.groupBox10.TabIndex = 26;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Выбрать изображение карты:";
            // 
            // changeMapFile_btn
            // 
            this.changeMapFile_btn.ForeColor = System.Drawing.Color.Black;
            this.changeMapFile_btn.Location = new System.Drawing.Point(213, 18);
            this.changeMapFile_btn.Name = "changeMapFile_btn";
            this.changeMapFile_btn.Size = new System.Drawing.Size(80, 23);
            this.changeMapFile_btn.TabIndex = 15;
            this.changeMapFile_btn.Text = "Изменить";
            this.changeMapFile_btn.UseVisualStyleBackColor = true;
            this.changeMapFile_btn.Click += new System.EventHandler(this.changeMapFile_btn_Click);
            // 
            // mapFilePath_tb
            // 
            this.mapFilePath_tb.Location = new System.Drawing.Point(9, 19);
            this.mapFilePath_tb.Name = "mapFilePath_tb";
            this.mapFilePath_tb.ReadOnly = true;
            this.mapFilePath_tb.Size = new System.Drawing.Size(199, 20);
            this.mapFilePath_tb.TabIndex = 15;
            // 
            // resertToDefaultMap_btn
            // 
            this.resertToDefaultMap_btn.ForeColor = System.Drawing.Color.Black;
            this.resertToDefaultMap_btn.Location = new System.Drawing.Point(9, 44);
            this.resertToDefaultMap_btn.Name = "resertToDefaultMap_btn";
            this.resertToDefaultMap_btn.Size = new System.Drawing.Size(284, 31);
            this.resertToDefaultMap_btn.TabIndex = 15;
            this.resertToDefaultMap_btn.Text = "Вернуть по умолчанию";
            this.resertToDefaultMap_btn.UseVisualStyleBackColor = true;
            this.resertToDefaultMap_btn.Click += new System.EventHandler(this.resertToDefaultMap_btn_Click);
            // 
            // saveSettings_btn
            // 
            this.saveSettings_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettings_btn.ForeColor = System.Drawing.Color.Black;
            this.saveSettings_btn.Location = new System.Drawing.Point(180, 267);
            this.saveSettings_btn.Name = "saveSettings_btn";
            this.saveSettings_btn.Size = new System.Drawing.Size(134, 39);
            this.saveSettings_btn.TabIndex = 45;
            this.saveSettings_btn.Text = "Сохранить";
            this.saveSettings_btn.UseVisualStyleBackColor = true;
            this.saveSettings_btn.Click += new System.EventHandler(this.saveSettings_btn_Click);
            // 
            // SelectMapFilePath
            // 
            this.SelectMapFilePath.FileName = "Map";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeMapFolderPath_btn);
            this.groupBox1.Controls.Add(this.mapFolderPath_tb);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(10, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 48);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь к папке с сохранениями карты (*.bin):";
            // 
            // changeMapFolderPath_btn
            // 
            this.changeMapFolderPath_btn.ForeColor = System.Drawing.Color.Black;
            this.changeMapFolderPath_btn.Location = new System.Drawing.Point(216, 17);
            this.changeMapFolderPath_btn.Name = "changeMapFolderPath_btn";
            this.changeMapFolderPath_btn.Size = new System.Drawing.Size(80, 23);
            this.changeMapFolderPath_btn.TabIndex = 14;
            this.changeMapFolderPath_btn.Text = "Изменить";
            this.changeMapFolderPath_btn.UseVisualStyleBackColor = true;
            this.changeMapFolderPath_btn.Click += new System.EventHandler(this.changeMapFolderPath_btn_Click);
            // 
            // mapFolderPath_tb
            // 
            this.mapFolderPath_tb.Location = new System.Drawing.Point(11, 19);
            this.mapFolderPath_tb.Name = "mapFolderPath_tb";
            this.mapFolderPath_tb.ReadOnly = true;
            this.mapFolderPath_tb.Size = new System.Drawing.Size(199, 20);
            this.mapFolderPath_tb.TabIndex = 1;
            // 
            // MapCalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(326, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveSettings_btn);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox3);
            this.MaximumSize = new System.Drawing.Size(342, 357);
            this.MinimumSize = new System.Drawing.Size(342, 357);
            this.Name = "MapCalibrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Калибровка карты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapCalibrationForm_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label mapX_lbl;
        private System.Windows.Forms.TextBox refLTX_tb;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveSettings_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox refRBY_tb;
        private System.Windows.Forms.TextBox refRBX_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox refLBY_tb;
        private System.Windows.Forms.TextBox refLBX_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox refRTY_tb;
        private System.Windows.Forms.TextBox refRTX_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refLTY_tb;
        private System.Windows.Forms.OpenFileDialog SelectMapFilePath;
        private System.Windows.Forms.Button resertToDefaultMap_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button changeMapFolderPath_btn;
        private System.Windows.Forms.TextBox mapFolderPath_tb;
        private System.Windows.Forms.FolderBrowserDialog ChoiceMapFolderPath;
        private System.Windows.Forms.Button changeMapFile_btn;
        private System.Windows.Forms.TextBox mapFilePath_tb;
    }
}