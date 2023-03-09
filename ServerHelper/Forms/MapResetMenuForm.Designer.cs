namespace ServerHelper.Forms
{
    partial class MapResetMenuForm
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
            this.bypassPrivates_cb = new System.Windows.Forms.CheckBox();
            this.saveDeletedFiles_cb = new System.Windows.Forms.CheckBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.reset_pb = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentCheckedFile_lbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.plan_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reset_btn = new System.Windows.Forms.Button();
            this.abort_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bypassPrivates_cb
            // 
            this.bypassPrivates_cb.AutoSize = true;
            this.bypassPrivates_cb.Location = new System.Drawing.Point(21, 119);
            this.bypassPrivates_cb.Name = "bypassPrivates_cb";
            this.bypassPrivates_cb.Size = new System.Drawing.Size(212, 17);
            this.bypassPrivates_cb.TabIndex = 20;
            this.bypassPrivates_cb.Text = "Не затрагивать приваты при сбросе";
            this.bypassPrivates_cb.UseVisualStyleBackColor = true;
            // 
            // saveDeletedFiles_cb
            // 
            this.saveDeletedFiles_cb.AutoSize = true;
            this.saveDeletedFiles_cb.Location = new System.Drawing.Point(21, 96);
            this.saveDeletedFiles_cb.Name = "saveDeletedFiles_cb";
            this.saveDeletedFiles_cb.Size = new System.Drawing.Size(270, 17);
            this.saveDeletedFiles_cb.TabIndex = 22;
            this.saveDeletedFiles_cb.Text = "Сохранить резервную копию удалённых файлов";
            this.saveDeletedFiles_cb.UseVisualStyleBackColor = true;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.ForeColor = System.Drawing.Color.Black;
            this.cancel_btn.Location = new System.Drawing.Point(6, 53);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(188, 27);
            this.cancel_btn.TabIndex = 24;
            this.cancel_btn.Text = "Отменить";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // reset_pb
            // 
            this.reset_pb.Location = new System.Drawing.Point(6, 19);
            this.reset_pb.Name = "reset_pb";
            this.reset_pb.Size = new System.Drawing.Size(394, 23);
            this.reset_pb.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.currentCheckedFile_lbl);
            this.groupBox1.Controls.Add(this.reset_pb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 71);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Прогресс сброса:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Текущий проверяемый файл:";
            // 
            // currentCheckedFile_lbl
            // 
            this.currentCheckedFile_lbl.AutoSize = true;
            this.currentCheckedFile_lbl.Location = new System.Drawing.Point(169, 47);
            this.currentCheckedFile_lbl.Name = "currentCheckedFile_lbl";
            this.currentCheckedFile_lbl.Size = new System.Drawing.Size(0, 13);
            this.currentCheckedFile_lbl.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.plan_btn);
            this.groupBox2.Controls.Add(this.cancel_btn);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 86);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Запланировать сброс на рестарт:";
            // 
            // plan_btn
            // 
            this.plan_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.plan_btn.ForeColor = System.Drawing.Color.Black;
            this.plan_btn.Location = new System.Drawing.Point(6, 20);
            this.plan_btn.Name = "plan_btn";
            this.plan_btn.Size = new System.Drawing.Size(188, 27);
            this.plan_btn.TabIndex = 25;
            this.plan_btn.Text = "Запланировать";
            this.plan_btn.UseVisualStyleBackColor = true;
            this.plan_btn.Click += new System.EventHandler(this.plan_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.reset_btn);
            this.groupBox3.Controls.Add(this.abort_btn);
            this.groupBox3.Location = new System.Drawing.Point(218, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 86);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сбросить карту сейчас:";
            // 
            // reset_btn
            // 
            this.reset_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reset_btn.ForeColor = System.Drawing.Color.Black;
            this.reset_btn.Location = new System.Drawing.Point(6, 20);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(188, 27);
            this.reset_btn.TabIndex = 25;
            this.reset_btn.Text = "Сбросить";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_ClickAsync);
            // 
            // abort_btn
            // 
            this.abort_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.abort_btn.ForeColor = System.Drawing.Color.Black;
            this.abort_btn.Location = new System.Drawing.Point(6, 53);
            this.abort_btn.Name = "abort_btn";
            this.abort_btn.Size = new System.Drawing.Size(188, 27);
            this.abort_btn.TabIndex = 24;
            this.abort_btn.Text = "Прервать";
            this.abort_btn.UseVisualStyleBackColor = true;
            this.abort_btn.Click += new System.EventHandler(this.abort_btn_Click);
            // 
            // MapResetMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(434, 251);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveDeletedFiles_cb);
            this.Controls.Add(this.bypassPrivates_cb);
            this.MaximumSize = new System.Drawing.Size(450, 290);
            this.MinimumSize = new System.Drawing.Size(450, 290);
            this.Name = "MapResetMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Сброс карты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapResetMenuForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox bypassPrivates_cb;
        private System.Windows.Forms.CheckBox saveDeletedFiles_cb;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ProgressBar reset_pb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label currentCheckedFile_lbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button plan_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button abort_btn;
        private System.Windows.Forms.Label label1;
    }
}