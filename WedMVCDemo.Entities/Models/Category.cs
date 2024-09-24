using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.Models
{
    public class Category : MainModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="Category name can not be more the 50 Chars")]
        [Display(Name ="Category name")]
        [Required(ErrorMessage = "Category name can not be empty")]
        public string CategoryName { get; set; }
        [StringLength(150)]
        [Display(Name = "Category description")]
        public string? CategoryDescription { get; set; }
    }
}
