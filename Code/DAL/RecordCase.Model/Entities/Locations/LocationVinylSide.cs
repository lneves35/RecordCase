using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationVinylSide")]
    public class LocationVinylSide: Location
    {
        public char Side { get; set; }
    }
}
