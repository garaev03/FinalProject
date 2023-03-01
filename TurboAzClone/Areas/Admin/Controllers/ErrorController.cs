namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Support,Admin,SuperAdmin")]
    public class ErrorController : Controller
    {
        public IActionResult NotFound() => View();
    }
}