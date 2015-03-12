using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.MusicTrackInstances
{
    [Table("MusicTrackInstanceFile")]
    public class MusicTrackInstanceFile : MusicTrackInstance
    {
        public string Filename { get; set; }

        public long FileSize { get; set; }

        public int Channels { get; set; }

        public int SampleRate { get; set; }
    }
}
