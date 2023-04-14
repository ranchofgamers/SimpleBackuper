using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBackupper.Core
{
    public class BackupData
    {
        public bool IsCompleted;
        public bool IsSkipped;
        public long Time;
        public string ZipFilePath;
        public Exception BackupException;
    }
}
