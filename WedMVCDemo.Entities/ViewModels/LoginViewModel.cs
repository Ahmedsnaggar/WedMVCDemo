using System.ComponentModel.DataAnnotations;

namespace WedMVCDemo.Entities.ViewModels
{
   public  class LoginViewModel
    {

        [StringLength(256)]
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Name can not be empty")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
