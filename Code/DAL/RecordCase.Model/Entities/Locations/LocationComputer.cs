using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationComputer")]
    public class LocationComputer : Location
    {
        [Index("IX_ComputerName", 1, IsUnique = true)]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}
