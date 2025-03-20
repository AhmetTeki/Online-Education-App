using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class RoleController(RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return View(values);
        }
    }
}
