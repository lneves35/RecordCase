using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Core.System
{
    public static class AppProps
    {
        public static string AppDataFullPath
        {
            get
            {
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            }

        }

        public static string AppDataFolder
        {
            get
            {
                return new FileInfo(AppDataFullPath).DirectoryName;
            }
        }
    }
}
