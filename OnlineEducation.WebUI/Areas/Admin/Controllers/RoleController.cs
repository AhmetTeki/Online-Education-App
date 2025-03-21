using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Entity.Entities;
using OnlineEducation.WebUI.DTOs.RoleDtos;
using OnlineEducation.WebUI.Services.RoleServices;
using System.Threading.Tasks;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class RoleController(IRoleService _roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleService.GetAllRolesAsync();
            return View(values);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
           await _roleService.CreateRoleAsync(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");

        }
    }
}
