using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.BannerDtos;
using OnlineEducation.WebUI.Helpers;
using OnlineEducation.WebUI.Services.UserServices;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeTeacherComponent(IUserService _userService) : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userService.GetAllTeacher();
            return View(values);
        }
    }
}
