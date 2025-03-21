using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.SocialMediaDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(values);
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"socialMedias/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            await _client.PostAsJsonAsync("socialMedias", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"socialMedias/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            await _client.PutAsJsonAsync("socialMedias", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
