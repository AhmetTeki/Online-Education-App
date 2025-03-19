using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.CourseDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetActiveCategories");
            return View(values);
        }
    }
}
