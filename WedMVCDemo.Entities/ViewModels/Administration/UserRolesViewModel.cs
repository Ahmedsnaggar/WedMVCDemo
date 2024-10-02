
namespace WedMVCDemo.Entities.ViewModels.Administration
{
    public class UserRolesViewModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<RolesCheckedViewModel> UserRoles { get; set; }
    }
}
