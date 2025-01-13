using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the condition

        // Navigation property for medications associated with this condition
        public List<Medication> Medications { get; set; }
    }
}
