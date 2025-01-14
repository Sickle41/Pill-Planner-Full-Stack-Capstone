namespace Capstone.Models;
public class MedicationSchedule
{
    public int Id { get; set; }
    public int MedicationId { get; set; }
    public Medication Medication { get; set; }
    
    public int DayOfWeekId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public int TimeOfDayId { get; set; }
    public TimeOfDay TimeOfDay { get; set; }
}
