using System;
using System.IO;
using NUnit.Framework;
using RecordCase.Core.Filesystem;
using RecordCase.TestsCommon;

namespace RecordCase.Core.Tests.IntegrationTests
{
    public abstract class BaseCoreIntegrationTest: BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(_testDir);
        }

        [TearDown]
        public void Cleanup()
        {
            dInfo.Empty();
            dInfo.Delete();
        }


        

    }
}
