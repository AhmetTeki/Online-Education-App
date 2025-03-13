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
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _client.DeleteAsync($"abouts/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            await _client.PostAsJsonAsync("abouts", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values =await _client.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            await _client.PutAsJsonAsync("abouts", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
