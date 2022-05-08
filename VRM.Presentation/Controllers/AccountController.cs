using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VRM.BLL.Services;
 
namespace VRM.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _acc;

        public AccountController(AccountService acc)
        {
            _acc = acc;
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}