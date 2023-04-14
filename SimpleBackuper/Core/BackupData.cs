using System;

namespace SimpleBackuper
{
    public struct BackupData
    {
        public bool IsComplete;
        public bool IsSkipped;
        public DateTime Time;
        public string FilePath;
        public Exception BackupException;
    }
}
