using SimpleBackupper.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleBackupper.Core
{
    public static class Configurator
    {
        public static List<string> GetConfig()
        {
            string cfgFilePath = $"{Settings.Default.APP_DIRECTORY}\\config.cfg";
            string source = string.Empty;

            using (FileStream fs = new FileStream(cfgFilePath, FileMode.OpenOrCreate))
            {
                using(StreamReader sr = new StreamReader(fs)) 
                {
                    string line = string.Empty;
                    while (line != null) 
                    {
                        line = sr.ReadLine();
                        if(line != null)
                            source += line;
                    }
                    if (source.Length == 0)
                    {
                        byte[] buffer = Encoding.Default.GetBytes("1cv8c.exe;");
                        fs.Write(buffer, 0, buffer.Length);
                        return new List<string>();
                    }
                }
            }
            string[] processNames = source.Trim().Split(';');
            if (processNames.Length == 0)
                return new List<string>();
            else
            {
                List<string> config = new List<string>();
                for (int i = 0; i < processNames.Length; i++)
                {
                    if (processNames[i] == string.Empty)
                        continue;
                    else config.Add(processNames[i]);
                }
                return config;
            }
        }
    }
}
