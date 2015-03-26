using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using RecordCase.Model.Entities;

namespace RecordCase.Business
{
    public partial class BusinessContext
    {
        public MusicTrack AddMusicTrackIfDoesntExist(MusicTrack musicTrack)
        {
            //Check if musicTrack exists
            var ctxMusicTrack = GetMusicTrack(musicTrack.Artist, musicTrack.Title);

            if (ctxMusicTrack != null)
                return ctxMusicTrack;

            return AddMusicTrack(musicTrack);
        }
        
        public MusicTrack GetMusicTrack(string artist, string title)
        {
            var predicate = PredicateBuilder.True<MusicTrack>();
            predicate = predicate.And(l =>
                l.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase)
                &&
                l.Title.Equals(title, StringComparison.OrdinalIgnoreCase)
                );
            return GetEntities(predicate).SingleOrDefault();
            
        }

        public MusicTrack AddMusicTrack(MusicTrack obj)
        {
            return InvokeUpdateOrInsert(rep => rep.Add, obj);
        }

    }
}
