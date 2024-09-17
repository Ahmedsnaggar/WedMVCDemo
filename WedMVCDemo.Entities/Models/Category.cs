using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name ="Category name")]
        public string CategoryName { get; set; }
        [StringLength(150)]
        [Display(Name = "Category description")]
        public string? CategoryDescription { get; set; }
    }
}
