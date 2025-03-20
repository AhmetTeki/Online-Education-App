using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.UserDtos;
using OnlineEducation.WebUI.Services.UserServices;

namespace OnlineEducation.WebUI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto dto)
        {
            var userRole = await _userService.LoginAsync(dto);
            if (userRole == "Admin")
            {
                return RedirectToAction("Index", "About", new {area="Admin"});
            }
            if (userRole == "Teacher")
            {
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            if (userRole == "Student")
            {
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }
            else
            {
                ModelState.AddModelError("","Email veya Şifre Hatalı");
                return View();
            }
                
        }
    }
}
