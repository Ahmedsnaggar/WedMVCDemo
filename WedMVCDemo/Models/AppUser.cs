using Microsoft.AspNetCore.Identity;

namespace WedMVCDemo.Models
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
