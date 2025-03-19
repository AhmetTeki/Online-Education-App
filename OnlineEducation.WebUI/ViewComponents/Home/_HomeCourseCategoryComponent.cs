using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.CourseCategoryDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeCourseCategoryComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories/GetActiveCategories");
            return View(values);
        }
    }
}
