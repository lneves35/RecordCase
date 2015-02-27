using System.Linq;
using NUnit.Framework;
using RecordCase.Model.Entities;

namespace RecordCase.Business.Tests.IntegrationTests
{
    [TestFixture]
    public class BusinessLayerTests : BaseBusinessIntegrationTest
    {
        [Test]
        public void GetAllGenres_ReturnsTrue()
        {
            //There must be some genres created on database initialization

            //Act
            var genres = businessContext.GetAllGenres();

            //Assert
            Assert.IsTrue(genres.Any(), "Got all genres");
        }

        [Test]
        public void AddLocation_ReturnsTrue()
        {
            //Arrange
            Location location = new Location()
            {
                Name = "teste"
            };

            //Act
            businessContext.AddLocation(location);
           
            //Assert
            Assert.IsTrue(location.LocationId != 0, "Location Added");
        }        
    }
}
