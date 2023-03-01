namespace TurboAzClone.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Rules()
            => View();

        public IActionResult Laws()
            => View();

        public IActionResult Privacy()
            => View();
    }
}