using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
