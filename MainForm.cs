using SimpleBackuper.Core;

namespace SimpleBackuper
{
    public partial class MainForm : Form
    {
        private Observer observer;
        public MainForm()
        {
            InitializeComponent();
            InitSettings();

            //TODO: ������� cfg � ��������� ��������.
            observer = new Observer("notepad.exe");
            observer.OnCreatedProcess += Observer_OnCreatedProcess;
            observer.OnDeletedProcess += Observer_OnDeletedProcess;
        }

        #region ��������� ������
        private void InitSettings()
        {
            BaseFile_tb.Text = Properties.Settings.Default.BaseFile;
            BackupsFolderPath_tb.Text = Properties.Settings.Default.BackupsFolderPath;
            IsStartWithWindows_cb.Checked = Properties.Settings.Default.IsStartWithWindows;
            IsStartTrayMinimize_cb.Checked = Properties.Settings.Default.IsStartTrayMinimize;
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
                Properties.Settings.Default.BaseFile = BaseFile_tb.Text;
                Properties.Settings.Default.BackupsFolderPath = BackupsFolderPath_tb.Text;
                Properties.Settings.Default.IsStartWithWindows = IsStartWithWindows_cb.Checked;
                Properties.Settings.Default.IsStartTrayMinimize = IsStartTrayMinimize_cb.Checked;
                Properties.Settings.Default.Save();
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
            NotifyIcon.BalloonTipTitle = "�� ��������, ��� �� ������� ���";
            NotifyIcon.BalloonTipText = "������ �������� ��������� ����� ����. ����������, ��������� ��������� ��������.";
            NotifyIcon.ShowBalloonTip(1000);
        }
        private void Observer_OnDeletedProcess()
        {
            NotifyIcon.BalloonTipTitle = "�� ��������, ��� �� ������� ���";
            NotifyIcon.BalloonTipText = "������ �������� ��������� ����� ����. ����������, ��������� ��������� ��������.";
            NotifyIcon.ShowBalloonTip(1000);
        }


        #endregion
    }
}