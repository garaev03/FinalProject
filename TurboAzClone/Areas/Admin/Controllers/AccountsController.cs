using Core.Entities.Concrets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> AddToRole(string userId, string rolename)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);
            if (user is null) { TempData["Message"] = "User tapılmadı"; return RedirectToAction("notfound", "error"); }
            IEnumerable<string> rolenameEnum = rolename.Split('\n');
            await _userManager.AddToRolesAsync(user, rolenameEnum);
            return RedirectToAction("all");
        }
    }
}
