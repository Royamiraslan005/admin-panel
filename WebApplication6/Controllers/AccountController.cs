using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.DAL;
using WebApplication6.Models;
using WebApplication6.ViewModels.Account;

namespace WebApplication6.Controllers
{

    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registr(RegistrVm registrVm)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            AppUser appUser = new AppUser()
            {
                Name = registrVm.Name,
                Email = registrVm.Email,
                Surname = registrVm.Surname,
                UserName = registrVm.Username,
            };
            var result = await _userManager.CreateAsync(appUser, registrVm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }
    }
}
