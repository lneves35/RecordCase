using System;
using System.IO;
using NUnit.Framework;

namespace RecordCase.TestsCommon
{
    public abstract class BaseTest
    {
        protected static string _testDir = String.Format(@"{0}\{1}", TestContext.CurrentContext.TestDirectory, "file_system_tests");
        protected static string _mp3Dir = String.Format(@"{0}\{1}", _testDir, "mp3");
        protected static DirectoryInfo dInfo = new DirectoryInfo(_testDir);
        
        protected const string DbFilename = "dummyDb.sdf";
        protected const string CollectionsFilename = "collections.dat";
        protected const string Mp3Filename = "Nick Curly - Sun City (Original Mix).mp3";

        protected static string DbFullPath = String.Format("{0}\\{1}", _testDir, DbFilename);
        protected static string Mp3FullPath = String.Format("{0}\\{1}", _mp3Dir, Mp3Filename);
        protected static string CollectionsFullPath = String.Format("{0}\\{1}", _testDir, CollectionsFilename);


    }
}
