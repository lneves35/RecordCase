using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.Locations
{
    public class DriveLetterLocation: Location
    {
        [Required]
        public string Letter { get; set; }
    }
}
