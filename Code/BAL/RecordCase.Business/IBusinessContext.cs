using System;
using System.Collections;
using System.Collections.Generic;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Business
{
    public interface IBusinessContext : IDisposable
    {
        IEnumerable<Genre> GetAllGenres();

        void AddLocation(Location location);
    }
}