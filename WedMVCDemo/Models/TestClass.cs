using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Models
{
    public class TestClass
    {
        [Display(Name = "Test Id")]
        public int Id { get; set; }
        [Display(Name = "Test Name")]
        public string Name { get; set; }
    }
}
