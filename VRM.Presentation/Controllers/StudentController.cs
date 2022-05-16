using Microsoft.AspNetCore.Mvc;

namespace VRM.Presentation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
