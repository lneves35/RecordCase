using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Entities.Locations
{
    [Table("LocationFolder")]
    public class LocationFolder : Location
    {
        public string FolderName { get; set; }
    }
}
