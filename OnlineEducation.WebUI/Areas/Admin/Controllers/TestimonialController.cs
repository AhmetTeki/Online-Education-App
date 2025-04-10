using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.TestimonialDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(values);
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync($"testimonials/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _client.PostAsJsonAsync("testimonials", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateTestimonialDto>($"testimonials/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _client.PutAsJsonAsync("testimonials", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
