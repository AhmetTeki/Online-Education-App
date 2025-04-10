using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.WebUI.Areas.Student.Controllers
{
    public class CourseRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
