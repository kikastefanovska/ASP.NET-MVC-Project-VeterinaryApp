using Microsoft.AspNetCore.Mvc;

namespace VeterinaryApp.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
