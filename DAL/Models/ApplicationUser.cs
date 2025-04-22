using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public Workers? Worker { get; set; }
    }
}
