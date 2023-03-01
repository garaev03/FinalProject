namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Support,Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        => View();
    }
}
