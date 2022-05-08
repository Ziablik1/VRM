using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VRM.Presentation.Models;

namespace VRM.Presentation.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
            model = roleManager.Roles.Select(r => new AppRoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
                NumberOfUsers = r.Users.Count
            }).ToList();
            return View(model);
        }
    }
}
