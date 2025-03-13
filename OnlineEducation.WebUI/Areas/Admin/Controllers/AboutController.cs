using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
