using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleBackuper.Core;
using SimpleBackuper.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;

namespace SimpleBackuper
{
    public partial class MainForm : Form
    {
        private Observer observer;
        public MainForm()
        {
            InitializeComponent();
            InitSettings();

            observer = new Observer(DeserializeConfig());
            observer.OnCreatedProcess += Observer_OnCreatedProcess;
            observer.OnDeletedProcess += Observer_OnDeletedProcess;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Settings.Default.IsStartTrayMinimize)
                WindowState = FormWindowState.Minimized;
        }

        #region ��������� ������
        private void InitSettings()
        {
            if (!InvokeRequired)
            {
                BaseFile_tb.Text = Settings.Default.BaseFile;
                BackupsFolderPath_tb.Text = Settings.Default.BackupsFolderPath;
                IsStartWithWindows_cb.Checked = Settings.Default.IsStartWithWindows;
                IsStartTrayMinimize_cb.Checked = Settings.Default.IsStartTrayMinimize;
                LastBackupTime_lbl.Text = $"��������� ����� ��������: {Settings.Default.LastBackupTime}";
                LastBackupPath_lbl.Text = $"����: {Settings.Default.LastBackupPath}";

                if (Settings.Default.IsStartWithWindows)
                    SetAutoRun(true);
                else SetAutoRun(false);
            }
            else
                this.Invoke(new Action(() =>
                {
                    InitSettings();
                }));
        }
        private List<string> DeserializeConfig()
        {
            string cfgFileName = "config.cfg";
            List<string> processNames = new List<string>();

            using (FileStream fs = new FileStream(cfgFileName, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader rs = new StreamReader(fs))
            {
                string source = string.Empty;
                string line = string.Empty;

                while (line != null)
                {
                    line = rs.ReadLine();
                    if (line != null)
                        source = source + line;
                }

                if (source == null || source == "")
                    return processNames;
                else
                {
                    string[] pn = source.Trim().Split(';');
                    if (pn.Length == 0)
                        return new List<string>();
                    else
                    {
                        for (int i = 0; i < pn.Length; i++)
                        {
                            if (pn[i] == string.Empty)
                                continue;
                            else processNames.Add(pn[i]);
                        }
                        return processNames;
                    }
                }
            }
        }
        private void SetAutoRun(bool autorun)
        {
            string name = Application.ProductName;
            RegistryKey reg;
            try
            {
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

                if (autorun)
                {
                    if (reg.GetValue(name) == null)
                        reg.SetValue(name, Assembly.GetExecutingAssembly().Location);
                }
                else
                {
                    if (reg.GetValue(name) != null)
                        reg.DeleteValue(name);
                }

                reg.Flush();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������� ������: " + ex.Message);
            }
        }
        #endregion

        #region ����������� ������� ������
        private void BaseFile_btn_Click(object sender, EventArgs e)
        {
            SelectFile.ShowDialog();
            if (SelectFile.FileName == null || SelectFile.FileName == "")
                return;

            Properties.Settings.Default.BaseFile = SelectFile.FileName;
            Properties.Settings.Default.Save();
            InitSettings();
        }
        private void BackupsFolderPath_btn_Click(object sender, EventArgs e)
        {
            SelectFolder.ShowDialog();
            if (SelectFolder.SelectedPath == null || SelectFolder.SelectedPath == "")
                return;

            Properties.Settings.Default.BackupsFolderPath = SelectFolder.SelectedPath;
            Properties.Settings.Default.Save();
            InitSettings();
        }
        private void SaveSettings_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.BaseFile = BaseFile_tb.Text;
                Settings.Default.BackupsFolderPath = BackupsFolderPath_tb.Text;
                Settings.Default.IsStartWithWindows = IsStartWithWindows_cb.Checked;
                Settings.Default.IsStartTrayMinimize = IsStartTrayMinimize_cb.Checked;
                Settings.Default.Save();

                if (Settings.Default.IsStartWithWindows)
                    SetAutoRun(true);
                else SetAutoRun(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�� ����� ���������� �������� ��������� ������: {ex.Message}", "����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("��������� ��������� �������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("�� ������������� ������ ������� ���������?", "�������?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region ����������� ��������� ������� �����
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                NotifyIcon.Visible = true;
                ShowBaloonTip("Simple Backuper", "���������� �������� � ������� ������. ���� ���� ��� ������ ��� �������!", 1000);
            }
            else
            {
                this.ShowInTaskbar = true;
                NotifyIcon.Visible = false;
            }
        }
        #endregion

        #region ����������� ���������
        private void Observer_OnCreatedProcess()
        {
            ShowBaloonTip("�� ��������, ��� �� ������� ���", "������ �������� ��������� ����� ����. ����������, ��������� ��������� ��������.", 1000);

            var result = Backuper.MakeBackup(Properties.Settings.Default.BaseFile, Properties.Settings.Default.BackupsFolderPath);

            if (result.IsComplete)
            {
                ShowBaloonTip("����������� ���������", "����� ���������� ������", 1000);
                Properties.Settings.Default.LastBackupPath = result.FilePath;
                Properties.Settings.Default.LastBackupTime = $"{result.Time.ToString("yyyy-MM-dd-HH-mm-sstt")}_UTC";
                Properties.Settings.Default.Save();
                InitSettings();
            }
            else if (result.BackupException is FileNotFoundException)
                ShowBaloonTip("����������� ����������� � �������", "����� ���������� ������, ������ ����� �� ��������� �.�. ���� � ���� ������ ������� ��� ���� �� ���������� ���� �� ����������", 1000);
            else
                ShowBaloonTip("����������� ����������� � �������", "����� ���������� ������, ������ ����� �� ���������", 1000);
        }
        private void Observer_OnDeletedProcess()
        {
            ShowBaloonTip("�� ��������, ��� �� ������� ���", "������ �������� ��������� ����� ����. ����������, ��������� ��������� ��������.", 1000);

            var result = Backuper.MakeBackup(Properties.Settings.Default.BaseFile, Properties.Settings.Default.BackupsFolderPath);

            if (result.IsComplete)
            {
                ShowBaloonTip("����������� ���������", "����� ���������� ������", 1000);
                Properties.Settings.Default.LastBackupPath = result.FilePath;
                Properties.Settings.Default.LastBackupTime = $"{result.Time.ToString("yyyy-MM-dd-HH-mm-sstt")}_UTC";
                Properties.Settings.Default.Save();
                InitSettings();
            }
            else if (result.BackupException is FileNotFoundException)
                ShowBaloonTip("����������� ����������� � �������", "����� ���������� ������, ������ ����� �� ��������� �.�. ���� � ���� ������ ������� ��� ���� �� ���������� ���� �� ����������", 1000);
            else
                ShowBaloonTip("����������� ����������� � �������", "����� ���������� ������, ������ ����� �� ���������", 1000);

        }
        private void ShowBaloonTip(string title, string text, int time)
        {
            NotifyIcon.BalloonTipTitle = title;
            NotifyIcon.BalloonTipText = text;
            NotifyIcon.ShowBalloonTip(time);
        }
        #endregion
    }
}