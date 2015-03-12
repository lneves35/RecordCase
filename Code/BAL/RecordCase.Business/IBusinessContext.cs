using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.MusicTrackInstances;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Business
{
    /// <summary>
    /// Here should be all methods necessary for the UI client
    /// </summary>
    public interface IBusinessContext : IDisposable
    {        
        IEnumerable<Genre> GetAllGenres();

        T AddLocationToContext<T>(T location) where T : Location;

        void ImportMusicTrack(FileInfo fileInfo);

        void ImportMusicTracks(string directoryPath, bool traverse);

    }
}