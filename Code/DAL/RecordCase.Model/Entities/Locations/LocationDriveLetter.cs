using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationDriveLetter")]
    public class LocationDriveLetter: Location
    {
        [Required]
        public string Letter { get; set; }
    }
}
