using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
