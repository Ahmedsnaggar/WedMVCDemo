using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.Models
{
    public class Store : MainModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string StoreName { get; set; }
        [StringLength(150)]
        public string? Address { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
