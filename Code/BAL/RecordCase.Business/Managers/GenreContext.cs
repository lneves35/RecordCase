using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Business
{
    public partial class BusinessContext
    {
        public IEnumerable<Genre> GetAllGenres()
        {
            return GetEntities<Genre>();
        }
    }
}
