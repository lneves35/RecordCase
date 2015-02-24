using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities
{
    public class MusicTrackInstance
    {
        public int MusicTrackInstanceId { get; set; }

        public int MusicTrackId { get; set; }

        public int LocationId { get; set; }

        public MusicTrack MusicTrack { get; set; }

        public Location Location { get; set; }
    }
}
