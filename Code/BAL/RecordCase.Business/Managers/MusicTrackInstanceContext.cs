using System.IO;
using System.Linq;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.MusicTrackInstances;
using LinqKit;

namespace RecordCase.Business
{
    public partial class BusinessContext
    {

        private T GetMusicTrackInstance<T>(int locationId, int musicTrackId) where T : MusicTrackInstance
        {
            var predicate = PredicateBuilder.True<T>().And(l => l.LocationId == locationId && l.MusicTrackId == musicTrackId);
            return GetEntities(predicate).SingleOrDefault();
        }

        public T AddMusicTrackInstance<T>(T musicTrackInstance) where T : MusicTrackInstance
        {
            //Add to database
            return InvokeUpdateOrInsert(rep => rep.Add, musicTrackInstance);
        }

        private T AddMusicTrackInstanceIfNotExists<T>(T obj) where T : MusicTrackInstance
        {
            //Check if instance exists
            var instance = GetMusicTrackInstance<T>(
                obj.LocationId,
                obj.MusicTrackId
                );

            if (instance != null)
                return instance;

            return AddMusicTrackInstance(obj);
        }

        
    }
}
