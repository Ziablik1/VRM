using Microsoft.AspNetCore.Mvc;
using VRM.DAL.Models;
using VRM.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace VRM.Presentation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                ViewBag.isLogged = true;
                return RedirectToLocal("Home/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                ViewBag.isLogged = false;
                return View(model);
            }

            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> SignOff()
        //    {
        //        await signInManager.SignOutAsync();
        //        return RedirectToAction("Login");
        //    }

        //    [HttpGet]
        //    public IActionResult AccessDenied(string returnUrl = null)
        //    {
        //        ViewData["ReturnUrl"] = returnUrl;
        //        return View();
        //}
    }
}
