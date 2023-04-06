using Microsoft.AspNetCore.Identity;

namespace HRMS.Models
{
    public class ApplicationUser:IdentityUser
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string? FullName { get; set; }
            
            public DateTime? DOB { get; set; }   
    }
}
