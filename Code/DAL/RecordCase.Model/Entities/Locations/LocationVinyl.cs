using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationVinyl")]
    public class LocationVinyl: Location
    {
        public int InchesId { get; set; }

        public Inches Inches { get; set; }
        
    }
}
