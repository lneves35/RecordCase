using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Model.Entities
{
    public class MusicTrack
    {
        public int MusicTrackId{ get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Length { get; set; }

        public string Key { get; set; }

        public int? Bpm { get; set; }

        public byte? Rating { get; set; }        

        public int? PlayCount { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        
        public DateTime? DatePlayed { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<MusicTrackInstance> MusicTrackInstances { get; set; }
    }
}
