using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.BannerDtos;
using OnlineEducation.WebUI.DTOs.BlogDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeBlogComponent: ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
    }
}
