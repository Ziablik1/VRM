using Microsoft.AspNetCore.Mvc;
using VRM.BLL.Services;

namespace VRM.Presentation.Controllers
{
    public class SignupController : Controller
    {
        public SignUpper _su;
        public SignupController(SignUpper su)
        {
            _su = su;
        }

        [HttpPost]
        public void SignUp()
        {
            _su.AddNewUser();
        }
    }
}
