using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.MusicTrackInstances;

namespace RecordCase.Business.FileFormatParsers
{
    public class FileFormatParserMp3 : IFileFormatParser
    {
        public MusicTrackInstance GetMusicTrackInstanceFile(System.IO.FileInfo fileInfo, Location location)
        {
            var tagLibFile = TagLib.File.Create(fileInfo.FullName);

            //Add MusicTrack
            var musicTrack = new MusicTrack()
            {
                Artist = tagLibFile.Tag.FirstPerformer,
                Title = tagLibFile.Tag.Title,
                Bpm = tagLibFile.Tag.BeatsPerMinute,
                DateAdded = DateTime.Now,
                Length = (int)tagLibFile.Properties.Duration.TotalSeconds,
            };

            return new MusicTrackInstanceFileMp3()
            {
                Bitrate = tagLibFile.Properties.AudioBitrate,
                Filename = fileInfo.Name,
                Channels = tagLibFile.Properties.AudioChannels,
                FileSize = fileInfo.Length,
                Location = location,
                MusicTrack = musicTrack
            };
        }
    }
}
