using System.IO;
using System.Linq;
using NUnit.Framework;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;
using RecordCase.Model.Entities.MusicTrackInstances;
using RecordCase.TestsCommon.Properties;

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
        public void ImportMusicTrack_DoesntThrow()
        {
            businessContext.ImportMusicTrack(new FileInfo(Mp3FullPath));
        }

        [Test]
        public void ImportMusicTracks_DoesntThrow()
        {
            businessContext.ImportMusicTracks("E:\\5 - CLOSED\\_2\\DISCO", true);
        }
        
    }
}
