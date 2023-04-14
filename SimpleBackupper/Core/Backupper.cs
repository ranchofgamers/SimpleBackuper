using Ionic.Zip;
using SimpleBackupper.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SimpleBackupper.Core
{
    public static class Backupper
    {
        public static BackupData MakeBackup(string baceFilePath, string backupsDirectory)
        {
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
                string zipFilePath = $"{backupsDirectory}\\backup_UTC_{date}.zip";

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
            }
        }
        private static void DeleteOldBackups(string backupsDirectory)
        {
            //TODO: Сделать через регулярные выражения и првоверять по имени файла
            if (!Directory.Exists(backupsDirectory))
                return;

            foreach (var file in Directory.GetFiles(backupsDirectory))
            {
                if (Path.GetExtension(file) == "zip")
                {
                    long creationTime = File.GetCreationTimeUtc(file).ToFileTimeUtc();
                    if (creationTime > DateTime.UtcNow.ToFileTimeUtc() - 604800)
                    {
                        try { File.Delete(file); }
                        catch(Exception) { continue; }
                    }
                }
            }
        }
    }
}
