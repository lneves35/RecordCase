//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace RecordCase.Model.Entities
//{
//    [Table("MusicFile")]
//    public class MusicFile
//    {
//        [Key]
//        public int MusicFileId { get; set; }

        

//        [Required]
//        public string Filename { get; set; }

//        public int FileSize { get; set; }

//        public int Bitrate { get; set; }

//        public int Channels { get; set; }

//        public int SampleRate { get; set; }

//        [ForeignKey("MusicTrack")]
//        public int MusicTrackId { get; set; }

//        public Location Location { get; set; }

//        public MusicTrack MusicTrack { get; set; }
//    }
//}
