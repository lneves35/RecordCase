using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordCase.Model.Entities.Locations
{
    [Table("HardDriveLocation")]
    public class HardDriveLocation: Location
    {
        [Required]
        public string SerialNumber { get; set; }
    }
}
