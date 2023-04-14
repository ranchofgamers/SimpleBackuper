using Ionic.Zip;
using SimpleBackuper.Properties;
using System;
using System.IO;
using System.Security.Cryptography;

namespace SimpleBackuper
{
    public static class Backuper
    {
        public static BackupData MakeBackup(string source, string backupsDirectory)
        {
            DateTime time = DateTime.Now;
            string fileName = "src.dat";

            if (backupsDirectory == null)
                backupsDirectory = "";

            try
            {
                fileName = Path.GetFileName(source);
                File.Copy(source, fileName, true);
                using (SHA256 sha = SHA256Managed.Create())
                {
                    using (FileStream fileStream = File.OpenRead(fileName))
                    {
                        string hash = Convert.ToBase64String(SHA256.Create().ComputeHash(fileStream));
                        if (hash == Settings.Default.LastHashSum)
                            return new BackupData() { IsComplete = false, IsSkipped = true, Time = time, FilePath = null, BackupException = null };
                        else
                        {
                            Settings.Default.LastHashSum = hash;
                            Settings.Default.Save();
                        }
                    }
                }

                string ext = ".zip";
                string date = time.ToString("yyyy-MM-dd-HH-mm-sstt");
                string zipFileName = $"{backupsDirectory}\\backup_{date}_UTC{ext}";
                int counter = 0;

                if (!Directory.Exists(backupsDirectory))
                    Directory.CreateDirectory(backupsDirectory);

                while (File.Exists(zipFileName))
                {
                    counter++;
                    zipFileName = $"{backupsDirectory}_{date}_UTC_{counter}{ext}";
                }
                using (ZipFile zip = new ZipFile(zipFileName))
                {
                    zip.UseZip64WhenSaving = Zip64Option.Always;
                    zip.CompressionMethod = CompressionMethod.None;

                    zip.AddFile(fileName);
                    zip.Save();
                }
                return new BackupData() { IsComplete = true, IsSkipped = false, Time = time, FilePath = zipFileName, BackupException = null };
            }
            catch (Exception ex)
            {
                return new BackupData() { IsComplete = false, IsSkipped = false, Time = time, FilePath = null, BackupException = ex };
            }
            finally
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                DeleteOldBackups(backupsDirectory);
            }
        }
        private static void DeleteOldBackups(string backupsDirectory)
        {
            if (!Directory.Exists(backupsDirectory))
                return;
            if (backupsDirectory == null)
                backupsDirectory = "";

            foreach (var file in Directory.GetFiles(backupsDirectory))
            {
                if (Path.GetExtension(file) == ".zip")
                {
                    var time = File.GetCreationTimeUtc(file);
                    if (time.ToFileTimeUtc() > DateTime.Now.ToFileTimeUtc() - 604800)
                    {
                        try { File.Delete(file); }
                        catch (Exception) { continue; }
                    }
                }
            }
        }
    }
}
