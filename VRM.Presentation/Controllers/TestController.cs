using Microsoft.AspNetCore.Mvc;
using VRM.BLL.Services;
namespace VRM.Presentation.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService testService;
        public TestController(ITestService _testService)
        {
            testService = _testService;
        }
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Index()
        {
            bool isStudent = User
                .Identities.FirstOrDefault(i => i.AuthenticationType == "Identity.Application")
                .Claims.Any(i => i.Value == "Student");
            ViewBag.isStudent = isStudent;

            var model = testService.GetAll();

            return View(model);
        }

        public IActionResult Participate()
        {
            return View();
        }
    }
}
