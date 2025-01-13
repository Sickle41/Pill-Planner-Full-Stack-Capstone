using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Medication Name

        [StringLength(255)]
        public string URLImage { get; set; } // Optional URL for an image of the medication

        [ForeignKey("User")]
        public int UserId { get; set; } // Foreign Key to associate the medication with a user
        public User User { get; set; } // Navigation property for EF Core

        [Required]
        [StringLength(500)]
        public string Description { get; set; } // Short description of the medication

        [Required]
        public int ConditionId { get; set; } // Foreign Key to the Condition
        public Condition Condition { get; set; } // Navigation property for EF Core

        // Navigation property for MedicationSchedules (many-to-many relationship with Schedule)
        public List<MedicationSchedule> MedicationSchedules { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; } // Optional notes for the medication
    }
}
