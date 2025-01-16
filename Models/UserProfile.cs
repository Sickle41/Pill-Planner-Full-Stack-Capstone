using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Capstone.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string IdentityUserId { get; set; }

        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; } // Used programmatically for role management.

        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;

        // Add other navigation properties if needed
        // e.g., public List<Comment> Comments { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
