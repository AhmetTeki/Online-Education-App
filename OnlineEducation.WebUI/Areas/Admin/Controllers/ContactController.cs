using Microsoft.AspNetCore.Mvc;
using OnlineEducation.WebUI.DTOs.AboutDtos;
using OnlineEducation.WebUI.DTOs.ContactDtos;
using OnlineEducation.WebUI.Helpers;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync($"contacts/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDtos dto)
        {
            await _client.PostAsJsonAsync("contacts", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateContact(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateContactDto>($"contacts/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            await _client.PutAsJsonAsync("contacts", dto);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
