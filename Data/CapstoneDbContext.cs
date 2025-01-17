using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;

namespace Capstone.Data;
public class CapstoneDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
    public DbSet<Timeslot> Timeslots { get; set; }

    public CapstoneDbContext(DbContextOptions<CapstoneDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure UserProfile-IdentityUser relationship
        modelBuilder.Entity<UserProfile>()
            .HasOne(up => up.IdentityUser)
            .WithOne()
            .HasForeignKey<UserProfile>(up => up.IdentityUserId);

        // Identity role seeding
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "ADMIN"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            CreateDateTime = DateTime.UtcNow
        });

        // Configure MedicationSchedule
        modelBuilder.Entity<MedicationSchedule>()
            .HasKey(ms => ms.Id); // Primary key

        modelBuilder.Entity<MedicationSchedule>()
            .HasOne(ms => ms.Medication)
            .WithMany(m => m.MedicationSchedules)
            .HasForeignKey(ms => ms.MedicationId);

        modelBuilder.Entity<MedicationSchedule>()
            .HasOne(ms => ms.Timeslot)
            .WithMany()
            .HasForeignKey(ms => ms.TimeslotId);

        // Timeslot seeding
        modelBuilder.Entity<Timeslot>().HasData(
            new Timeslot { Id = 1, Description = "Monday Morning" },
            new Timeslot { Id = 2, Description = "Monday Afternoon" },
            new Timeslot { Id = 3, Description = "Monday Evening" },
            new Timeslot { Id = 4, Description = "Tuesday Morning" },
            new Timeslot { Id = 5, Description = "Tuesday Afternoon" },
            new Timeslot { Id = 6, Description = "Tuesday Evening" },
            new Timeslot { Id = 7, Description = "Wednesday Morning" },
            new Timeslot { Id = 8, Description = "Wednesday Afternoon" },
            new Timeslot { Id = 9, Description = "Wednesday Evening" },
            new Timeslot { Id = 10, Description = "Thursday Morning" },
            new Timeslot { Id = 11, Description = "Thursday Afternoon" },
            new Timeslot { Id = 12, Description = "Thursday Evening" },
            new Timeslot { Id = 13, Description = "Friday Morning" },
            new Timeslot { Id = 14, Description = "Friday Afternoon" },
            new Timeslot { Id = 15, Description = "Friday Evening" },
            new Timeslot { Id = 16, Description = "Saturday Morning" },
            new Timeslot { Id = 17, Description = "Saturday Afternoon" },
            new Timeslot { Id = 18, Description = "Saturday Evening" },
            new Timeslot { Id = 19, Description = "Sunday Morning" },
            new Timeslot { Id = 20, Description = "Sunday Afternoon" },
            new Timeslot { Id = 21, Description = "Sunday Evening" }
        );
    }
}
