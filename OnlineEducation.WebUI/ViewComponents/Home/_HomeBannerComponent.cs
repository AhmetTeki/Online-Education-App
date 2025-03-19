using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.WebUI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
