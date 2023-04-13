using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SimpleBackuper.Core
{
    public static class Backuper
    {
        public static BackupData MakeBackup(string source, string path)
        {
            DateTime time = DateTime.Now;

            try
            {
                string ext = ".zip";
                string date = time.ToString("yyyy-MM-dd-HH-mm-sstt");
                string fileName = $"{path}\\backup_{date}_UTC{ext}";
                int counter = 0;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                while (File.Exists(fileName))
                {
                    counter++;
                    fileName = $"{path}_{date}_UTC_{counter}{ext}";
                }
                using (ZipFile zip = new ZipFile(fileName))
                {
                    zip.UseZip64WhenSaving = Zip64Option.Always;
                    zip.CompressionMethod = CompressionMethod.None;

                    zip.AddFile(source);
                    zip.Save();
                }
                return new BackupData() { IsComplete = true, Time = time, FilePath = fileName, BackupException = null };
            }
            catch (Exception ex)
            {
                return new BackupData() { IsComplete = false, Time = time, FilePath = null, BackupException = ex };
            }
        }
    }
}
