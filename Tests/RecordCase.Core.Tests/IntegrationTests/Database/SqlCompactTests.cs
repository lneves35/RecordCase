using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using RecordCase.Core.Database;

namespace RecordCase.Core.Tests.IntegrationTests.Database
{
    [TestFixture]
    public class SqlCompactControllerTests : BaseCoreIntegrationTest
    {
        
        [TestCase]
        public void CreateDatabaseTest()
        {
            //ARRANGE
            var fullPath = String.Format(@"{0}\{1}", _testDir, DbFilename);
            var controller = new SqlCompactController();

            //ACT
            controller.CreateDb(fullPath);

            //ASSERT
            Assert.IsTrue(Directory.EnumerateFiles(_testDir).Any(f => f.Equals(fullPath)));
        }

        [TestCase]
        public void DeleteDatabaseTest()
        {
            //Arrange
            var fullPath = String.Format(@"{0}\{1}", _testDir, DbFilename);
            var controller = new SqlCompactController();
            controller.CreateDb(fullPath);

            //Act
            controller.DeleteDb(fullPath);

            //Assert
            Assert.IsTrue(!dInfo.EnumerateFiles().Any());

        }

    }
}
