using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Common.Exceptions;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;

namespace RecordCase.Business
{
    public static class EntityValidationExtensions
    {
        public static void Validate(this Location location)
        {
            if (location is LocationVinylSide)
            {
                if (location.ParentLocation == null || !(location.ParentLocation is LocationVinyl))
                    throw new RecordCaseValidationException("A vinyl side must have a vinyl as parent location");
            }
        }
    }
}
