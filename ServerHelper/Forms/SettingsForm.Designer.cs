namespace ServerHelper.Forms
{
    partial class SettingsForm
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
            this.isStartAppWithWindows_cb = new System.Windows.Forms.CheckBox();
            this.isStartServerWithApp_cb = new System.Windows.Forms.CheckBox();
            this.saveAppSettings_btn = new System.Windows.Forms.Button();
            this.isStartAppMinimize_cb = new System.Windows.Forms.CheckBox();
            this.isStartBotWithApp_cb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // isStartAppWithWindows_cb
            // 
            this.isStartAppWithWindows_cb.AutoSize = true;
            this.isStartAppWithWindows_cb.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.isStartAppWithWindows_cb.ForeColor = System.Drawing.Color.Black;
            this.isStartAppWithWindows_cb.Location = new System.Drawing.Point(13, 13);
            this.isStartAppWithWindows_cb.Name = "isStartAppWithWindows_cb";
            this.isStartAppWithWindows_cb.Size = new System.Drawing.Size(249, 17);
            this.isStartAppWithWindows_cb.TabIndex = 0;
            this.isStartAppWithWindows_cb.Text = "Запускать приложение при старте Windows";
            this.isStartAppWithWindows_cb.UseVisualStyleBackColor = false;
            // 
            // isStartServerWithApp_cb
            // 
            this.isStartServerWithApp_cb.AutoSize = true;
            this.isStartServerWithApp_cb.ForeColor = System.Drawing.Color.Black;
            this.isStartServerWithApp_cb.Location = new System.Drawing.Point(13, 37);
            this.isStartServerWithApp_cb.Name = "isStartServerWithApp_cb";
            this.isStartServerWithApp_cb.Size = new System.Drawing.Size(241, 17);
            this.isStartServerWithApp_cb.TabIndex = 1;
            this.isStartServerWithApp_cb.Text = "Запускать сервер при старте приложения";
            this.isStartServerWithApp_cb.UseVisualStyleBackColor = true;
            // 
            // saveAppSettings_btn
            // 
            this.saveAppSettings_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAppSettings_btn.ForeColor = System.Drawing.Color.Black;
            this.saveAppSettings_btn.Location = new System.Drawing.Point(604, 398);
            this.saveAppSettings_btn.Name = "saveAppSettings_btn";
            this.saveAppSettings_btn.Size = new System.Drawing.Size(184, 40);
            this.saveAppSettings_btn.TabIndex = 8;
            this.saveAppSettings_btn.Text = "Сохранить настройки";
            this.saveAppSettings_btn.UseVisualStyleBackColor = true;
            this.saveAppSettings_btn.Click += new System.EventHandler(this.saveAppSettings_btn_Click);
            // 
            // isStartAppMinimize_cb
            // 
            this.isStartAppMinimize_cb.AutoSize = true;
            this.isStartAppMinimize_cb.ForeColor = System.Drawing.Color.Black;
            this.isStartAppMinimize_cb.Location = new System.Drawing.Point(13, 86);
            this.isStartAppMinimize_cb.Name = "isStartAppMinimize_cb";
            this.isStartAppMinimize_cb.Size = new System.Drawing.Size(201, 17);
            this.isStartAppMinimize_cb.TabIndex = 9;
            this.isStartAppMinimize_cb.Text = "Запускать в свёрнутом состоянии";
            this.isStartAppMinimize_cb.UseVisualStyleBackColor = true;
            // 
            // isStartBotWithApp_cb
            // 
            this.isStartBotWithApp_cb.AutoSize = true;
            this.isStartBotWithApp_cb.ForeColor = System.Drawing.Color.Black;
            this.isStartBotWithApp_cb.Location = new System.Drawing.Point(13, 61);
            this.isStartBotWithApp_cb.Name = "isStartBotWithApp_cb";
            this.isStartBotWithApp_cb.Size = new System.Drawing.Size(289, 17);
            this.isStartBotWithApp_cb.TabIndex = 10;
            this.isStartBotWithApp_cb.Text = "Подключать дискорд бота при запуске приложения";
            this.isStartBotWithApp_cb.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.isStartBotWithApp_cb);
            this.Controls.Add(this.isStartAppMinimize_cb);
            this.Controls.Add(this.saveAppSettings_btn);
            this.Controls.Add(this.isStartServerWithApp_cb);
            this.Controls.Add(this.isStartAppWithWindows_cb);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isStartAppWithWindows_cb;
        private System.Windows.Forms.CheckBox isStartServerWithApp_cb;
        private System.Windows.Forms.Button saveAppSettings_btn;
        private System.Windows.Forms.CheckBox isStartAppMinimize_cb;
        private System.Windows.Forms.CheckBox isStartBotWithApp_cb;
    }
}