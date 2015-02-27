using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationHardDrive")]
    public class LocationHardDrive: Location
    {
        [Required]
        public string SerialNumber { get; set; }
    }
}
