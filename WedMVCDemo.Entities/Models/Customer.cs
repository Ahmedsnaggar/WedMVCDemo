using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.Models
{
    public class Customer : MainModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string? Address { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [StringLength(200)]
        public string? Email { get; set; }
        [StringLength(150)]
        public string? WebSite { get; set; }
    }
}
