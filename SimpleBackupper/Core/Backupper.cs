using Ionic.Zip;
using SimpleBackupper.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SimpleBackupper.Core
{
    public static class Backupper
    {
        public static bool IsBusy { get; private set; } = false;

        private const string prefix = "backup_UTC_";
        private const long unixDeltaTime = 604800; //Неделя в сек.

        public static BackupData MakeBackup(string baceFilePath, string backupsDirectory)
        {
            IsBusy = true;

            long backupingStartTime = DateTime.Now.ToFileTimeUtc();

            if (!File.Exists(baceFilePath))
                throw new FileNotFoundException("Указанный файл базы не существует");


            if(backupsDirectory == null || backupsDirectory == string.Empty) 
                backupsDirectory = Settings.Default.APP_DIRECTORY;

            if (!Directory.Exists(backupsDirectory))
                Directory.CreateDirectory(backupsDirectory);

            string tempBaseFilePath = $"{Settings.Default.APP_DIRECTORY}\\{Path.GetFileName(baceFilePath)}";

            try
            {
                File.Copy(baceFilePath, tempBaseFilePath, true);
                using (SHA256 sha256 = SHA256.Create())
                {
                    using (FileStream fs = File.OpenRead(tempBaseFilePath))
                    {
                        string hash = Convert.ToBase64String(SHA256.Create().ComputeHash(fs));
                        if (hash == Settings.Default.LastHashSum)
                            return new BackupData() { IsCompleted = false, IsSkipped = true, Time = backupingStartTime, ZipFilePath = null, BackupException = null };
                        else
                        {
                            Settings.Default.LastHashSum = hash;
                            Settings.Default.Save();
                        }
                    }
                }

                string date = DateTime.FromFileTimeUtc(backupingStartTime).ToString("yyyy-MM-dd-HH-mm-sstt");
                string zipFilePath = $"{backupsDirectory}\\{prefix}{date}.zip";

                int counter = 0;
                while (File.Exists(zipFilePath))
                {
                    counter++;
                    zipFilePath = $"{backupsDirectory}\\backup_UTC_{date}_{counter}.zip";
                }
                using (ZipFile zip = new ZipFile(zipFilePath))
                {
                    zip.UseZip64WhenSaving = Zip64Option.Always;
                    zip.CompressionMethod = CompressionMethod.None;

                    zip.AddFile(baceFilePath);
                    zip.Save();
                }
                return new BackupData() { IsCompleted = true, IsSkipped = false, Time = backupingStartTime, ZipFilePath = zipFilePath, BackupException = null };

            }
            catch (Exception ex)
            {
                return new BackupData() { IsCompleted = false, IsSkipped = false, Time = backupingStartTime, ZipFilePath = null, BackupException = ex };
            }
            finally
            {
                if(File.Exists(tempBaseFilePath))
                    File.Delete(tempBaseFilePath);
                DeleteOldBackups(backupsDirectory);
                IsBusy = false;
            }
        }
        private static void DeleteOldBackups(string backupsDirectory)
        {
            if (!Directory.Exists(backupsDirectory))
                return;

            foreach (var file in Directory.GetFiles(backupsDirectory))
            {
                try
                {
                    if (Path.GetExtension(file) != ".zip")
                        continue;

                    Regex filter = new Regex($"{prefix}" + @"\d{4}-\d{2}-\d{2}-\d{2}-\d{2}-\d{2}" + ".zip");

                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                    if (!filter.IsMatch(Path.GetFileName(file)))
                        continue;

                    var UTCparseDate = fileNameWithoutExt.Replace(prefix, "").Split('-');

                    var UTCCreationTime = new DateTime(
                        Convert.ToInt32(UTCparseDate[0]),
                        Convert.ToInt32(UTCparseDate[1]),
                        Convert.ToInt32(UTCparseDate[2]),
                        Convert.ToInt32(UTCparseDate[3]),
                        Convert.ToInt32(UTCparseDate[4]),
                        Convert.ToInt32(UTCparseDate[5]));

                    if (((DateTimeOffset)UTCCreationTime).ToUnixTimeSeconds() < ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds() - unixDeltaTime)
                    {
                        try { File.Delete(file); }
                        catch (Exception) { continue; }
                    }
                }
                catch (Exception) { continue; }
            }
        }
    }
}
