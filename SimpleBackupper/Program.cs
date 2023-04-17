using Microsoft.Win32;
using SimpleBackupper.Core;
using SimpleBackupper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBackupper
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                return;

            Settings.Default.APP_DIRECTORY = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Settings.Default.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
