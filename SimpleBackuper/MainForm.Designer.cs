namespace SimpleBackuper
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LastBackupPath_lbl = new System.Windows.Forms.Label();
            this.LastBackupTime_lbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AutoStartSwitcher_btn = new System.Windows.Forms.Button();
            this.BackupsFolderPath_btn = new System.Windows.Forms.Button();
            this.BackupsFolderPath_tb = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BaseFile_btn = new System.Windows.Forms.Button();
            this.BaseFile_tb = new System.Windows.Forms.TextBox();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SelectFile = new System.Windows.Forms.OpenFileDialog();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LastBackupPath_lbl);
            this.groupBox1.Controls.Add(this.LastBackupTime_lbl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация:";
            // 
            // LastBackupPath_lbl
            // 
            this.LastBackupPath_lbl.AutoSize = true;
            this.LastBackupPath_lbl.Location = new System.Drawing.Point(6, 41);
            this.LastBackupPath_lbl.Name = "LastBackupPath_lbl";
            this.LastBackupPath_lbl.Size = new System.Drawing.Size(201, 13);
            this.LastBackupPath_lbl.TabIndex = 1;
            this.LastBackupPath_lbl.Text = "Путь к резервной копии: C:\\Something";
            // 
            // LastBackupTime_lbl
            // 
            this.LastBackupTime_lbl.AutoSize = true;
            this.LastBackupTime_lbl.Location = new System.Drawing.Point(6, 21);
            this.LastBackupTime_lbl.Name = "LastBackupTime_lbl";
            this.LastBackupTime_lbl.Size = new System.Drawing.Size(220, 13);
            this.LastBackupTime_lbl.TabIndex = 0;
            this.LastBackupTime_lbl.Text = "Последняя копия создана (UTC): 00:00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 116);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки резервного копирования:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AutoStartSwitcher_btn);
            this.groupBox4.Controls.Add(this.BackupsFolderPath_btn);
            this.groupBox4.Controls.Add(this.BackupsFolderPath_tb);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 66);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 47);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Папка для сохранения копий:";
            // 
            // AutoStartSwitcher_btn
            // 
            this.AutoStartSwitcher_btn.Location = new System.Drawing.Point(6, 45);
            this.AutoStartSwitcher_btn.Name = "AutoStartSwitcher_btn";
            this.AutoStartSwitcher_btn.Size = new System.Drawing.Size(321, 25);
            this.AutoStartSwitcher_btn.TabIndex = 2;
            this.AutoStartSwitcher_btn.Text = "Включить (отключить) автозагрузку с Windows";
            this.AutoStartSwitcher_btn.UseVisualStyleBackColor = true;
            // 
            // BackupsFolderPath_btn
            // 
            this.BackupsFolderPath_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupsFolderPath_btn.Location = new System.Drawing.Point(252, 19);
            this.BackupsFolderPath_btn.Name = "BackupsFolderPath_btn";
            this.BackupsFolderPath_btn.Size = new System.Drawing.Size(75, 20);
            this.BackupsFolderPath_btn.TabIndex = 1;
            this.BackupsFolderPath_btn.Text = "изменить";
            this.BackupsFolderPath_btn.UseVisualStyleBackColor = true;
            this.BackupsFolderPath_btn.Click += new System.EventHandler(this.BackupsFolderPath_btn_Click);
            // 
            // BackupsFolderPath_tb
            // 
            this.BackupsFolderPath_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupsFolderPath_tb.Location = new System.Drawing.Point(6, 19);
            this.BackupsFolderPath_tb.Name = "BackupsFolderPath_tb";
            this.BackupsFolderPath_tb.ReadOnly = true;
            this.BackupsFolderPath_tb.Size = new System.Drawing.Size(237, 20);
            this.BackupsFolderPath_tb.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BaseFile_btn);
            this.groupBox3.Controls.Add(this.BaseFile_tb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Путь к базе ЭРЖ (файл *.1CD):";
            // 
            // BaseFile_btn
            // 
            this.BaseFile_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseFile_btn.Location = new System.Drawing.Point(252, 19);
            this.BaseFile_btn.Name = "BaseFile_btn";
            this.BaseFile_btn.Size = new System.Drawing.Size(75, 20);
            this.BaseFile_btn.TabIndex = 1;
            this.BaseFile_btn.Text = "изменить";
            this.BaseFile_btn.UseVisualStyleBackColor = true;
            this.BaseFile_btn.Click += new System.EventHandler(this.BaseFile_btn_Click);
            // 
            // BaseFile_tb
            // 
            this.BaseFile_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseFile_tb.Location = new System.Drawing.Point(6, 19);
            this.BaseFile_tb.Name = "BaseFile_tb";
            this.BaseFile_tb.ReadOnly = true;
            this.BaseFile_tb.Size = new System.Drawing.Size(237, 20);
            this.BaseFile_tb.TabIndex = 0;
            // 
            // SelectFile
            // 
            this.SelectFile.Filter = "1CD (*.1CD)|*.1CD";
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Simple Backuper работает";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 186);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 225);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Backuper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LastBackupPath_lbl;
        private System.Windows.Forms.Label LastBackupTime_lbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button AutoStartSwitcher_btn;
        private System.Windows.Forms.Button BackupsFolderPath_btn;
        private System.Windows.Forms.TextBox BackupsFolderPath_tb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BaseFile_btn;
        private System.Windows.Forms.TextBox BaseFile_tb;
        private System.Windows.Forms.FolderBrowserDialog SelectFolder;
        private System.Windows.Forms.OpenFileDialog SelectFile;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}

