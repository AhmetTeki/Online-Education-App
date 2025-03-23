using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.ContactDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderContact : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }
    }
}
