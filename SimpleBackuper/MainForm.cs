using IWshRuntimeLibrary;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using SimpleBackuper.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using File = System.IO.File;

namespace SimpleBackuper
{
    public partial class MainForm : Form
    {
        private Observer observer;
        private ContextMenu m_menu = new ContextMenu();

        public MainForm()
        {
            InitializeComponent();
            InitSettings();

            m_menu.MenuItems.Add(0, new MenuItem("Выход", new EventHandler(Exit)));
            NotifyIcon.ContextMenu = m_menu;

            observer = new Observer(ConfigManager.GetConfig());
            //observer.OnCreatedProcess += Observer_OnCreatedProcess;
            observer.OnDeletedProcess += Observer_OnDeletedProcess;

            SystemEvents.SessionEnding += SystemEvents_SessionEnding;

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            NotifyIcon.Visible = true;
        }

        #region Приватные методы
        private void InitSettings()
        {
            if (!InvokeRequired)
            {
                BaseFile_tb.Text = Settings.Default.BaseFile;
                BackupsFolderPath_tb.Text = Settings.Default.BackupsFolderPath;
                LastBackupTime_lbl.Text = $"Последняя копия создана (UTC): {Settings.Default.LastBackupTime}";
                LastBackupPath_lbl.Text = $"Путь к резервной копии: {Settings.Default.LastBackupPath}";
                SetAutoRun(true);
            }
            else this.Invoke(new System.Action(() =>
            {
                InitSettings();
            }));
        }
        private void MakeBackup()
        {
            var result = Backuper.MakeBackup(Settings.Default.BaseFile, Settings.Default.BackupsFolderPath);

            if (result.IsSkipped == true)
                return;

            if (result.IsComplete)
            {
                Settings.Default.LastBackupPath = result.FilePath;
                Settings.Default.LastBackupTime = $"{result.Time:yyyy.MM.dd - HH:mm:sstt}";
                Settings.Default.Save();
                InitSettings();
            }
            else if (result.BackupException is FileNotFoundException)
                MessageBox.Show("Резервное копирование базы ЭРЖ не удалось т.к. база по указанному пути не обнаружена. Проверьте настройки приложения.", "Simple Backuper",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (result.BackupException is IOException) { }
            else
                MessageBox.Show("Резервное копирование базы ЭРЖ не удалось.", "Simple Backuper",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SetAutoRun(bool autorun)
        {
            object shortPath = (object)"Startup";
            if (autorun)
            {
                WshShell shell = new WshShell();
                string link = Path.Combine(((string)shell.SpecialFolders.Item(ref shortPath)), Application.ProductName + @".lnk");
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(link);

                shortcut.IconLocation = Assembly.GetExecutingAssembly().Location;
                shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;
                shortcut.Save();
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + Application.ProductName + @".lnk"))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + Application.ProductName + @".lnk");

            //using (TaskService ts = new TaskService())
            //{
            //    TaskDefinition td = ts.NewTask();

            //    td.RegistrationInfo.Description = "Автозапуск SimpleBackuper";
            //    td.Triggers.Add(new BootTrigger() { Enabled = true });
            //    td.Actions.Add(new ExecAction("notepad.exe"));
            //    ts.RootFolder.RegisterTaskDefinition(@"Test", td);
            //    ts.RootFolder.DeleteTask("Test");
            //}

            //string name = Application.ProductName;
            //RegistryKey reg;
            //try
            //{
            //    reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true);

            //    if (autorun)
            //        reg.SetValue(name, Assembly.GetExecutingAssembly().Location);
            //    else
            //    {
            //        if (reg.GetValue(name) != null)
            //            reg.DeleteValue(name);
            //    }

            //    reg.Flush();
            //    reg.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Произошла ошибка: " + ex.Message);
            //}
        }
        #endregion

        #region Обработчики изменения размера формы
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NotifyIcon.Visible = true;
            }
            else
            {
                ShowInTaskbar = true;
                NotifyIcon.Visible = false;
            }
        }
        #endregion

        #region Обработчики нажатия кнопок
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }
        private void BaseFile_btn_Click(object sender, EventArgs e)
        {
            SelectFile.ShowDialog();
            if (SelectFile.FileName == null || SelectFile.FileName == "")
                return;

            Settings.Default.BaseFile = SelectFile.FileName;
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
            Settings.Default.IsStartWithWindows = !Settings.Default.IsStartWithWindows;
            Settings.Default.Save();

            SetAutoRun(Settings.Default.IsStartWithWindows);
            if (Settings.Default.IsStartWithWindows)
                MessageBox.Show("Автозагрузка с включеним Windows активна", "Автозагрузка", MessageBoxButtons.OK);
            else MessageBox.Show("Автозагрузка с включеним Windows отключена", "Автозагрузка", MessageBoxButtons.OK);

        }
        private void Exit(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        #endregion

        #region Обработчики Обсервера
        private void Observer_OnDeletedProcess()
        {
            MakeBackup();
        }
        private void Observer_OnCreatedProcess()
        {
            MakeBackup();
        }
        #endregion

        #region Системные обработчики
        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            Exit(sender, e);
        }
        #endregion
    }
}
