using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.BannerDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            await _client.PostAsJsonAsync("banners", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            await _client.PutAsJsonAsync("banners", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
