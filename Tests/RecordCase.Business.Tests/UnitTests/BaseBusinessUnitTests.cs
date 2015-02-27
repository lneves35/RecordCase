using NUnit.Framework;
using RecordCase.Core.Database.Interfaces;
using RecordCase.TestsCommon;

namespace RecordCase.Business.Tests.UnitTests
{
    public class BaseBusinessUnitTests
    {
        private IUnitOfWork unitOfWork;
        protected IBusinessContext businessContext;

        [SetUp]
        public void Setup()
        {            
            unitOfWork = new FakeUnitOfWork();
            businessContext = new BusinessContext(unitOfWork);
        }

        [TearDown]
        public void Cleanup()
        {
            businessContext.Dispose();
        }
    }
}
