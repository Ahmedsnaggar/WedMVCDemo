using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WedMVCDemo.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public double DefaultPrice { get; set; }
        [ForeignKey(nameof(category))]
        public int categoryId { get; set; }
        public Category? category { get; set; }
        public string? ProductImage { get; set; }
    }
}
