using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.WebUI.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]/{id?}")]
    [Area("Admin")]
    public class AboutController(HttpClient _client) : Controller
    {
        public IActionResult Index()
        {
            //var values=_client.GetFromJsonAsync<>
            return View();
        }
    }
}
