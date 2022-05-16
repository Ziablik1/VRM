using Microsoft.AspNetCore.Mvc;

namespace VRM.Presentation.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
