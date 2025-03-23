using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.ContactDtos;
using OnlineEducation.WebUI.DTOs.SocialMediaDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderSocialMedia: ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
    }
}
