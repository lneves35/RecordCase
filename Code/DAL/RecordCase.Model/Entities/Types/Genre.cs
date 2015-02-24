using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecordCase.Model.Entities.Types
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<MusicTrack> MusicTracks { get; set; }
    }
}
