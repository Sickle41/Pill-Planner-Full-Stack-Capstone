using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // Name of the schedule (e.g., Morning, Afternoon, Evening)

        // Navigation property for many-to-many relationship with Medications
        public List<MedicationSchedule> MedicationSchedules { get; set; }
    }
}
