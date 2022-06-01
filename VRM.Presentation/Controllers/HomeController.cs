using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using VRM.BLL.Services;
using VRM.DAL.Models;
using VRM.Presentation.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace VRM.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool isAdmin = User
                .Identities.FirstOrDefault(i => i.AuthenticationType == "Identity.Application")
                .Claims.Any(i => i.Value == "Admin");
            ViewBag.isAdmin = isAdmin;
            bool isStudent = User
                .Identities.FirstOrDefault(i => i.AuthenticationType == "Identity.Application")
                .Claims.Any(i => i.Value == "Student");
            ViewBag.isStudent = isStudent;

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