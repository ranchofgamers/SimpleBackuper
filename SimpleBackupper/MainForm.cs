using SimpleBackupper.Core;
using SimpleBackupper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleBackupper
{
    public partial class MainForm : Form
    {
        private Observer observer;

        public MainForm()
        {
            InitializeComponent();
            InitSettings();
            InitTrayView();

            observer = new Observer(Configurator.GetConfig());
            observer.OnDeletedProcess += Observer_OnDeletedProcess;
            observer.Start();
        }

        #region Приватные методы
        private void InitSettings()
        {
            if (!InvokeRequired)
            {
                BaseFilePath_tb.Text = Settings.Default.BaseFilePath;
                BackupsFolderPath_tb.Text = Settings.Default.BackupsFolderPath;

                LastBackupTime_lbl.Text = $"Последняя копия создана (UTC): {DateTime.FromFileTimeUtc(Settings.Default.LastBackupTime):yyyy.MM.dd - HH:mm:sstt}";
                LastBackupPath_lbl.Text = $"Путь к резервной копии: {Settings.Default.LastBackupPath}";
            }
            else Invoke(new Action(() => { InitSettings(); }));
        }
        private void InitTrayView()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(0, new MenuItem("Выход", new EventHandler(Exit)));

            NotifyIcon.ContextMenu = menu;
            NotifyIcon.Visible = true;
        }
        private void MakeBackup()
        {
            var result = Backupper.MakeBackup(Settings.Default.BaseFilePath, Settings.Default.BackupsFolderPath);

            if (result.IsSkipped)
                return;

            if (result.IsCompleted)
            {
                Settings.Default.LastBackupPath = result.ZipFilePath;
                Settings.Default.LastBackupTime = result.Time;
                Settings.Default.Save();
                InitSettings();
            }
            else if (result.BackupException is FileNotFoundException)
                MessageBox.Show("Резервное копирование базы ЭРЖ не удалось т.к. база по указанному пути не обнаружена. Проверьте настройки приложения.", "Simple Backupper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result.BackupException is IOException)
                MessageBox.Show("Резервное копирование базы ЭРЖ не удалось т.к. база занята каким-то другим приложением.", "Simple Backupper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Резервное копирование базы ЭРЖ не удалось.", "Simple Backupper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Обработчики обсервера
        private void Observer_OnDeletedProcess()
        {
            MakeBackup();
        }
        #endregion

        #region Обработчики нажатия кнопок на форме
        private void BaseFilePath_btn_Click(object sender, EventArgs e)
        {
            SelectFile.ShowDialog();
            if (SelectFile.FileName == null || SelectFile.FileName == "")
                return;

            Settings.Default.BaseFilePath = SelectFile.FileName;
            Settings.Default.Save();
            InitSettings();
        }
        private void BackupsFolderPath_btn_Click(object sender, EventArgs e)
        {
            SelectFolder.ShowDialog();
            if (SelectFolder.SelectedPath == null || SelectFolder.SelectedPath == "")
                return;

            Settings.Default.BackupsFolderPath = SelectFolder.SelectedPath;
            Settings.Default.Save();
            InitSettings();
        }
        private void AutoStartSwitcher_btn_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Обработчики уровня приложения
        private void Exit(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }
        #endregion

        #region Обработчики поведения формы
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                ShowInTaskbar = false;
            else ShowInTaskbar = true;

        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }
        #endregion
    }
}
