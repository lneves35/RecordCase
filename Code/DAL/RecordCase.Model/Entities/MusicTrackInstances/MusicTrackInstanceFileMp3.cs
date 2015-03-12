using System.ComponentModel.DataAnnotations.Schema;

namespace RecordCase.Model.Entities.MusicTrackInstances
{
    [Table("MusicTrackInstanceFileMp3")]
    public class MusicTrackInstanceFileMp3 : MusicTrackInstanceFile
    {
        public int Bitrate { get; set; }
    }
}
