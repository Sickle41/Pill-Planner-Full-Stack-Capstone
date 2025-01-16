using System.ComponentModel.DataAnnotations;


namespace Capstone.Models
{
    public class MedicationSchedule
    {
        public int Id { get; set; } // Primary Key
        
        [Required]
        public int MedicationId { get; set; } // Foreign Key
        public Medication Medication { get; set; } // Navigation Property
        
        [Required]
        public int TimeslotId { get; set; } // Foreign Key to Timeslot
        public Timeslot Timeslot { get; set; } // Navigation Property
    }
}
