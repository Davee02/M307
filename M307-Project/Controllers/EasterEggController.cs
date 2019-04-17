using Microsoft.AspNetCore.Mvc;

namespace M307_Project.Controllers
{
    public class EasterEggController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
