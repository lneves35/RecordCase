using System.ComponentModel.DataAnnotations.Schema;

namespace RecordCase.Model.Entities.Locations
{
    [Table("HardDriveLocation")]
    public class HardDriveLocation: Location
    {
        public string SerialNumber { get; set; }
    }
}
