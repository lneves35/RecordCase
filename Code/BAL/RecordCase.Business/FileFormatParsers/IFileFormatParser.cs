using System.IO;
using RecordCase.Business.Entities;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.MusicTrackInstances;

namespace RecordCase.Business.FileFormatParsers
{
    public interface IFileFormatParser
    {
        MusicTrackInstance GetMusicTrackInstanceFile(FileInfo fileInfo, Location location);
    }
}
