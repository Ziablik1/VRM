using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VRM.BLL.Services;
using VRM.Presentation.Models;

namespace VRM.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Service1 _s;

        public HomeController(ILogger<HomeController> logger, Service1 s)
        {
            _logger = logger;
            _s = s;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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