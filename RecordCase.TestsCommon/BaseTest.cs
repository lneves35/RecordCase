using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecordCase.TestsCommon
{
    public abstract class BaseTest
    {
        protected static string _testDir = String.Format(@"{0}\{1}", TestContext.CurrentContext.TestDirectory, "file_system_tests");
        protected static DirectoryInfo dInfo = new DirectoryInfo(_testDir);
        
        protected const string DbFilename = "dummyDb.sdf";
        protected static string DbFullPath = String.Format("{0}\\{1}", _testDir, DbFilename);
    }
}
