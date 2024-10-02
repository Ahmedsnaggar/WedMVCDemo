using Microsoft.AspNetCore.Identity;
using WedMVCDemo.Entities.Models;

namespace WedMVCDemo.Models
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
