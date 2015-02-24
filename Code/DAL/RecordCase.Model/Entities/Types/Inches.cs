using System.ComponentModel.DataAnnotations;

namespace RecordCase.Model.Entities.Types
{
    public class Inches
    {
        public int InchesId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
