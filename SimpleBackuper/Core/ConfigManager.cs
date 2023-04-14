using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleBackuper
{
    public static class ConfigManager
    {
        public static List<string> GetConfig()
        {
            string cfgFileName = "config.cfg";
            List<string> processNames = new List<string>();

            using (FileStream fs = new FileStream(cfgFileName, FileMode.OpenOrCreate))
            using (StreamReader rs = new StreamReader(fs))
            {
                string source = string.Empty;
                string line = string.Empty;

                while (line != null)
                {
                    line = rs.ReadLine();
                    if (line != null)
                        source = source + line;
                }

                if (source == null || source == "")
                {
                    byte[] buffer = Encoding.Default.GetBytes("1cv8c.exe;");
                    fs.Write(buffer, 0, buffer.Length);
                    return processNames;
                }
                else
                {
                    string[] pn = source.Trim().Split(';');
                    if (pn.Length == 0)
                        return new List<string>();
                    else
                    {
                        for (int i = 0; i < pn.Length; i++)
                        {
                            if (pn[i] == string.Empty)
                                continue;
                            else processNames.Add(pn[i]);
                        }
                        return processNames;
                    }
                }
            }
        }
    }
}
