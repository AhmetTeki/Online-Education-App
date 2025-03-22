using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.UserDtos;
using OnlineEducation.WebUI.Services.UserServices;

namespace OnlineEducation.WebUI.Controllers
{
    public class RegisterController(IUserService _userService) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            if (!result.Succeeded || !ModelState.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code,item.Description);
                }
                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }
    }
}
