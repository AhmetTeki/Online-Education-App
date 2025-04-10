using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.BannerDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent: ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
