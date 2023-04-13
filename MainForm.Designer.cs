namespace SimpleBackuper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            IsStartWithWindows_cb = new CheckBox();
            IsStartTrayMinimize_cb = new CheckBox();
            SaveSettings_btn = new Button();
            groupBox6 = new GroupBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            BaseFile_btn = new Button();
            BaseFile_tb = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            BackupsFolderPath_btn = new Button();
            BackupsFolderPath_tb = new TextBox();
            SelectFile = new OpenFileDialog();
            SelectFolder = new FolderBrowserDialog();
            NotifyIcon = new NotifyIcon(components);
            groupBox6.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // IsStartWithWindows_cb
            // 
            IsStartWithWindows_cb.AutoSize = true;
            IsStartWithWindows_cb.Location = new Point(6, 25);
            IsStartWithWindows_cb.Name = "IsStartWithWindows_cb";
            IsStartWithWindows_cb.Size = new Size(195, 19);
            IsStartWithWindows_cb.TabIndex = 0;
            IsStartWithWindows_cb.Text = "Запускать при старте Windows";
            IsStartWithWindows_cb.UseVisualStyleBackColor = true;
            // 
            // IsStartTrayMinimize_cb
            // 
            IsStartTrayMinimize_cb.AutoSize = true;
            IsStartTrayMinimize_cb.Location = new Point(6, 50);
            IsStartTrayMinimize_cb.Name = "IsStartTrayMinimize_cb";
            IsStartTrayMinimize_cb.Size = new Size(182, 19);
            IsStartTrayMinimize_cb.TabIndex = 4;
            IsStartTrayMinimize_cb.Text = "Запускать свёрнутым в трей";
            IsStartTrayMinimize_cb.UseVisualStyleBackColor = true;
            // 
            // SaveSettings_btn
            // 
            SaveSettings_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveSettings_btn.Location = new Point(223, 19);
            SaveSettings_btn.Name = "SaveSettings_btn";
            SaveSettings_btn.Size = new Size(85, 55);
            SaveSettings_btn.TabIndex = 5;
            SaveSettings_btn.Text = "Сохранить настройки";
            SaveSettings_btn.UseVisualStyleBackColor = true;
            SaveSettings_btn.Click += SaveSettings_btn_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(IsStartTrayMinimize_cb);
            groupBox6.Controls.Add(SaveSettings_btn);
            groupBox6.Controls.Add(IsStartWithWindows_cb);
            groupBox6.Dock = DockStyle.Bottom;
            groupBox6.Location = new Point(0, 213);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(314, 83);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Настройки приложения:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 40);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 8;
            label4.Text = "В папку: C:\\something";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BaseFile_btn);
            groupBox2.Controls.Add(BaseFile_tb);
            groupBox2.Location = new Point(12, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(292, 55);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Путь к базе (файл .*1CD):";
            // 
            // BaseFile_btn
            // 
            BaseFile_btn.Location = new Point(211, 22);
            BaseFile_btn.Name = "BaseFile_btn";
            BaseFile_btn.Size = new Size(75, 23);
            BaseFile_btn.TabIndex = 4;
            BaseFile_btn.Text = "изменить";
            BaseFile_btn.UseVisualStyleBackColor = true;
            BaseFile_btn.Click += BaseFile_btn_Click;
            // 
            // BaseFile_tb
            // 
            BaseFile_tb.Location = new Point(6, 22);
            BaseFile_tb.Name = "BaseFile_tb";
            BaseFile_tb.Size = new Size(199, 23);
            BaseFile_tb.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 10;
            label1.Text = "Бэкап сохранен: 00:00:00";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(314, 70);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 70);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(314, 143);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Настройки бэкапа:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BackupsFolderPath_btn);
            groupBox4.Controls.Add(BackupsFolderPath_tb);
            groupBox4.Location = new Point(11, 79);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(292, 55);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Папка для бэкапов:";
            // 
            // BackupsFolderPath_btn
            // 
            BackupsFolderPath_btn.Location = new Point(211, 22);
            BackupsFolderPath_btn.Name = "BackupsFolderPath_btn";
            BackupsFolderPath_btn.Size = new Size(75, 23);
            BackupsFolderPath_btn.TabIndex = 4;
            BackupsFolderPath_btn.Text = "изменить";
            BackupsFolderPath_btn.UseVisualStyleBackColor = true;
            BackupsFolderPath_btn.Click += BackupsFolderPath_btn_Click;
            // 
            // BackupsFolderPath_tb
            // 
            BackupsFolderPath_tb.Location = new Point(6, 22);
            BackupsFolderPath_tb.Name = "BackupsFolderPath_tb";
            BackupsFolderPath_tb.Size = new Size(199, 23);
            BackupsFolderPath_tb.TabIndex = 3;
            // 
            // SelectFile
            // 
            SelectFile.Filter = "1CD (*.1CD)|*.1CD";
            // 
            // NotifyIcon
            // 
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "Simple Backuper";
            NotifyIcon.Visible = true;
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 296);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox6);
            MaximizeBox = false;
            MinimumSize = new Size(330, 335);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Backuper";
            FormClosing += MainForm_FormClosing;
            Resize += MainForm_Resize;
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox IsStartWithWindows_cb;
        private CheckBox IsStartTrayMinimize_cb;
        private Button SaveSettings_btn;
        private GroupBox groupBox6;
        private Label label4;
        private GroupBox groupBox2;
        private Button BaseFile_btn;
        private TextBox BaseFile_tb;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button BackupsFolderPath_btn;
        private TextBox BackupsFolderPath_tb;
        private OpenFileDialog SelectFile;
        private FolderBrowserDialog SelectFolder;
        private NotifyIcon NotifyIcon;
    }
}