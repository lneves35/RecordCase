using System.IO;
using NUnit.Framework;
using RecordCase.Core.Database;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Core.Filesystem;
using RecordCase.Model;
using RecordCase.Repository;
using RecordCase.TestsCommon;

namespace RecordCase.Business.Tests.IntegrationTests
{
    public class BaseBusinessIntegrationTest: BaseTest
    {
        private SqlCompactController dBcontroller = new SqlCompactController();
        private string connString;
        private IUnitOfWork unitOfWork;
        private RecordCaseContext dbContext;
        protected IBusinessContext businessContext;

        [SetUp]
        public void Setup()
        {
            if (dInfo.Exists)
                dInfo.Empty();
            Directory.CreateDirectory(_mp3Dir);
            FileIO.WriteToFile(Mp3FullPath, TestsCommon.Properties.Resources.FileMp3);

            connString = dBcontroller.CreateDb(DbFullPath);
            dbContext = new RecordCaseContextForTests(connString, RecordCaseContextSeeder.GetSeeder());
            unitOfWork = new UnitOfWork(dbContext, true);
            businessContext = new BusinessContext(unitOfWork);
        }

        [TearDown]
        public void Cleanup()
        {
            businessContext.Dispose();
            dBcontroller.DeleteDb(DbFullPath);
        }
    }
}
