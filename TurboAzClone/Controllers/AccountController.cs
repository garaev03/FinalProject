using Business.Services.Interfaces;
using Business.Utilities.Messages;
using Business.Utilities.Validations.AppUserValidations;
using Core.Entities.Concrets;
using Entities.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Controllers
{
    public class AccountController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly LoginValidator _loginValidator;
        private readonly RegisterValidator _registerValidator;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager, LoginValidator loginValidator, RegisterValidator registerValidator, IVehicleService vehicleService)
        {
            _userManager = userManager;
            _signManager = signManager;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
            _vehicleService = vehicleService;
        }

        public IActionResult Login()
               => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!_loginValidator.ValidateAsync(loginDto).Result.IsValid) return View();
            AppUser? user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) { ModelState.AddModelError("", "Email yada Parol səhvdir."); return View(); }
            var result = await _signManager.PasswordSignInAsync(user, loginDto.Password, true, false);
            if (!result.Succeeded) { ModelState.AddModelError("", "Email yada Parol səhvdir."); return View(); }
            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
            => View();
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!_registerValidator.ValidateAsync(registerDto).Result.IsValid) return View();
            AppUser NewUser = new()
            {
                UserName = registerDto.Name + "-" + registerDto.PhoneNumber.Trim().Replace(" ", ""),
                Email = registerDto.Email,
                FirstName = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber.Trim().Replace(" ", "")
            };
            var result = await _userManager.CreateAsync(NewUser, registerDto.Password);
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                if (error.Code is "DuplicateEmail")
                    ModelState.AddModelError("", Messages.DuplicateEmail);
                else if (error.Code is "DuplicateUserName")
                    ModelState.AddModelError("", Messages.DuplicateUserName);
                else
                    ModelState.AddModelError("", error.Description + error.Code);
                return View();
            }
            await _userManager.AddToRoleAsync(NewUser, "User");
            return RedirectToAction("login");
        }

        [Authorize]
        public async Task<IActionResult> Confirmeds()
        {
            var user= await _userManager.GetUserAsync(User);
            var list = await _vehicleService.GetAllAsync(x => x.isConfirmed && !x.isExpired && x.PhoneNumber.Number == user.PhoneNumber,true);
            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> Expireds()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _vehicleService.GetAllAsync(x => x.isExpired && x.PhoneNumber.Number == user.PhoneNumber, true);
            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> Cancelleds()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _vehicleService.GetAllAsync(x => x.isCancelled && !x.isExpired && x.PhoneNumber.Number == user.PhoneNumber, true);
            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> Awaits()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _vehicleService.GetAllAsync(x => x.inAwait && !x.isExpired && x.PhoneNumber.Number == user.PhoneNumber, true);
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
