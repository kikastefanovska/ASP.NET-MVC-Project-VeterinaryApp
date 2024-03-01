using Microsoft.AspNetCore.Mvc;

namespace VeterinaryApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
