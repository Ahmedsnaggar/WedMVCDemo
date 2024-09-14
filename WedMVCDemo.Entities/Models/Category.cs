using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(150)]
        public string? CategoryDescription { get; set; }
    }
}
