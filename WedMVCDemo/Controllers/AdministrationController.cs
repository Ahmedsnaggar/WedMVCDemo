using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WedMVCDemo.Entities.ViewModels.Administration;
using WedMVCDemo.Models;

namespace WedMVCDemo.Controllers
{
    [Authorize(Roles ="AdminsRole")]
    public class AdministrationController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region Roles
        public async Task<IActionResult> GetAllRole()
        {
            var roles = await _roleManager.Roles.Select(r => new RolesViewModel()
            {
                Id = r.Id,
                RoleName = r.Name
            }).ToListAsync();
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            string RoleId = Guid.NewGuid().ToString();
            RolesViewModel roles = new RolesViewModel() { Id = RoleId};
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RolesViewModel item)
        {
            if (ModelState.IsValid)
            {
                chec: 
                var IsExists = await _roleManager.FindByIdAsync(item.Id);
                if (IsExists != null)
                {
                    item.Id = Guid.NewGuid().ToString();
                    goto chec;
                }
                var newrole = new IdentityRole()
                {
                    Id=item.Id,
                    Name = item.RoleName
                };
                var result = await _roleManager.CreateAsync(newrole);
                if(result.Succeeded)
                {
                    return RedirectToAction("GetAllRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(item);
        }
        #endregion

        #region Users
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.Select(u => new UsersViewModel()
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Roles = _userManager.GetRolesAsync(u).Result
            }).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return RedirectToAction("GetAllUsers");
            }

            var roles = await _roleManager.Roles.ToListAsync();

            var model = new UserRolesViewModel()
            {
                UserID = user.Id,
                UserName = user.UserName,
                UserEmail = user.Email,

                UserRoles = roles.Select(r => new RolesCheckedViewModel()
                {
                    RoleName = r.Name,
                    ISSelected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList(),
            };


            return View(model);
        }

        public async Task<IActionResult> UpdateRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserID);
            if (user == null)
            {
                return RedirectToAction("GetAllUsers");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, model.UserRoles.Where(r=> r.ISSelected).Select(rr=> rr.RoleName).ToList());

            return RedirectToAction("GetAllUsers");
        }
        #endregion
    }
}
