using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.CourseCategoryDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");
            return View(values);
        }
        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"coursecategories/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateCourseCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto dto)
        {
            await _client.PostAsJsonAsync("coursecategories", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"coursecategories/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto dto)
        {
            await _client.PutAsJsonAsync("coursecategories", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}
