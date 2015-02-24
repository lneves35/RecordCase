using System.Linq;
using NUnit.Framework;

namespace RecordCase.Business.Tests.IntegrationTests
{
    [TestFixture]
    public class BusinessLayerTests : BaseBusinessIntegrationTest
    {
        [Test]
        public void GetAllGenres_ReturnsTrue()
        {
            //There should be some genres created on database initialization

            //Act
            var genres = businessContext.GetAllGenres();

            //Assert
            Assert.IsTrue(genres.Any(), "Got all genres");
        }
    }
}
