using Microsoft.AspNetCore.Identity;

namespace Capstone.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

     public ICollection<Medication> Medications { get; set; }

    // Navigation property for medication schedules
    public ICollection<MedicationSchedule> MedicationSchedules { get; set; }

}