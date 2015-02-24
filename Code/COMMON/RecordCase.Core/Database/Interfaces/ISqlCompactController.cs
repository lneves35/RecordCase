using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordCase.Core.Database.Interfaces
{
    public interface ISqlCompactController
    {
        string CreateDb(string filename, string password);
        void DeleteDb(string filename);
    }
}
