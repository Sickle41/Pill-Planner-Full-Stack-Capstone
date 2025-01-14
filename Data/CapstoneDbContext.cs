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
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
    public DbSet<DayOfWeek> DaysOfWeek { get; set; }
    public DbSet<TimeOfDay> TimesOfDay { get; set; }

    public CapstoneDbContext(DbContextOptions<CapstoneDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity role seeding
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
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
            UserId = "dbc40bc6-0829-4a53-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
        });

        // Configure MedicationSchedule
        modelBuilder.Entity<MedicationSchedule>()
            .HasKey(ms => ms.Id); // Primary key

        modelBuilder.Entity<MedicationSchedule>()
            .HasOne(ms => ms.Medication)
            .WithMany(m => m.MedicationSchedules)
            .HasForeignKey(ms => ms.MedicationId);

        modelBuilder.Entity<MedicationSchedule>()
            .HasOne(ms => ms.DayOfWeek)
            .WithMany()
            .HasForeignKey(ms => ms.DayOfWeekId);

        modelBuilder.Entity<MedicationSchedule>()
            .HasOne(ms => ms.TimeOfDay)
            .WithMany()
            .HasForeignKey(ms => ms.TimeOfDayId);

        // Seed DayOfWeek data
        modelBuilder.Entity<DayOfWeek>().HasData(
            new DayOfWeek { Id = 1, Name = "Monday" },
            new DayOfWeek { Id = 2, Name = "Tuesday" },
            new DayOfWeek { Id = 3, Name = "Wednesday" },
            new DayOfWeek { Id = 4, Name = "Thursday" },
            new DayOfWeek { Id = 5, Name = "Friday" },
            new DayOfWeek { Id = 6, Name = "Saturday" },
            new DayOfWeek { Id = 7, Name = "Sunday" }
        );

        // Seed TimeOfDay data
        modelBuilder.Entity<TimeOfDay>().HasData(
            new TimeOfDay { Id = 1, Name = "Morning" },
            new TimeOfDay { Id = 2, Name = "Afternoon" },
            new TimeOfDay { Id = 3, Name = "Evening" }
        );
    }
}
