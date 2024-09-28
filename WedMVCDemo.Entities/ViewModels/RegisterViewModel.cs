using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(256)]
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Name can not be empty")]
        public string UserName { get; set; }
        [StringLength(256)]
        [Display(Name = "User email")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmePassword { get; set; }
    }
}
