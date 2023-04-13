using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBackuper.Core
{
    public struct BackupData
    {
        public bool IsComplete;
        public DateTime Time;
        public string? FilePath;
        public Exception? BackupException;
    }
}
