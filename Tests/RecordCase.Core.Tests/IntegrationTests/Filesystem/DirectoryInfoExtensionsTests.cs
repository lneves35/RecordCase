using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using RecordCase.Core.Filesystem;


namespace RecordCase.Core.Tests.IntegrationTests.Filesystem
{
    [TestFixture]
    public class DirectoryInfoExtensionsTests : BaseCoreIntegrationTest
    {
        [Test]
        public void EmptyDirectoryTest()
        {
            //Arrange            
            const string newDir = "newDir";
            var dir = Directory.CreateDirectory(String.Format(@"{0}\{1}\{2}", _testDir, newDir, newDir));
            var file = File.Create(dir.FullName + @"\tmp.txt");
            file.Dispose();

            //Act
            dInfo.Empty();

            //Assert
            Assert.IsTrue(!dInfo.EnumerateFiles().Any() && !dInfo.EnumerateDirectories().Any());
        }
        
    }
}
