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
        public IActionResult Index()
        {
            var model = testService.GetAll();
            return View(model);
        }
        public IActionResult Participate()
        {
            return View();
        }
    }
}
