using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Entity.Entities;
using OnlineEducation.WebUI.DTOs.UserDtos;
using OnlineEducation.WebUI.Services.UserServices;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class RoleAssignController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values =await _userService.GetAllUsersAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user =await _userService.GetAllUsersByIdAsync(id);
            TempData["userId"] = user.Id;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var item in roles)
            {
                var assignRole = new AssignRoleDto();
                assignRole.RoleId = item.Id;
                assignRole.RoleName = item.Name;
                assignRole.RoleExist = userRoles.Contains(item.Name);

                assignRoleList.Add(assignRole);
            }
            return View(assignRoleList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> dto)
        {
            int userId =(int)TempData["userId"];
            var user =await _userService.GetAllUsersByIdAsync(userId);

            foreach (var item in dto)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user,item.RoleName);
                }
                else
                {
                  await  _userManager.RemoveFromRoleAsync(user,item.RoleName );
                }
            }
            return RedirectToAction("Index");
        }
    }
}
