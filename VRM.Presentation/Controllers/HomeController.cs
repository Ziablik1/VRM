using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VRM.BLL.Services;
using VRM.Presentation.Models;

namespace VRM.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<string> AddUser()
        {
            //ApplicationUser user;
            //ApplicationUserStore Store = new ApplicationUserStore(new ApplicationDbContext());
            //ApplicationUserManager userManager = new ApplicationUserManager(Store);
            //user = new ApplicationUser
            //{
            //    UserName = "TestUser",
            //    Email = "TestUser@test.com"
            //};

            //var result = await userManager.CreateAsync(user);
            //if (!result.Succeeded)
            //{
            //    return result.Errors.First();
            //}
            return "User Added";
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}