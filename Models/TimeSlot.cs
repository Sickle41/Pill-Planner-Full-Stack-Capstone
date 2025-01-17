using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Timeslot
    {
        [Key]
        public int Id { get; set; } // Primary Key
        
        [Required]
        [StringLength(50)]
        public string Description { get; set; } // Description of the Timeslot (e.g., "Monday Morning")
    }
}
