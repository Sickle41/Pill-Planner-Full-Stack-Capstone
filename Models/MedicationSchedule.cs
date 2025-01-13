namespace Capstone.Models
{
    public class MedicationSchedule
    {
        // Foreign Key for Medication
        public int MedicationId { get; set; }
        public Medication Medication { get; set; } // Navigation Property

        // Foreign Key for Schedule
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } // Navigation Property
    }
}
