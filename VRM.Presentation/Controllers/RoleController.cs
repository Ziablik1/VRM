using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VRM.DAL.Data;
using VRM.DAL.Models;
using VRM.Presentation.Models;

namespace VRM.Presentation.Controllers
{
    public class RoleController : Controller
    { 
            private readonly RoleManager<AppRole> roleManager;

            public RoleController(RoleManager<AppRole> roleManager)
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
            }).ToList();
            return View(model);
        }
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            RoleViewModel model = new RoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                AppRole applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    model.Id = applicationRole.Id;
                    model.RoleName = applicationRole.Name;
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(string id, RoleViewModel model)
        {

            bool isExist = !String.IsNullOrEmpty(id);
            AppRole applicationRole = isExist ? await roleManager.FindByIdAsync(id) :
           new AppRole
           {

           };
            applicationRole.Name = model.RoleName;
            IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(applicationRole)
                                                : await roleManager.CreateAsync(applicationRole);
            if (roleRuslt.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddEditApplicationRole(string id)
        {
            RoleViewModel model = new RoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                AppRole applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    model.Id = applicationRole.Id;
                    model.RoleName = applicationRole.Name;
                }
            }
            return PartialView("_AddEditApplicationRole", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditApplicationRole(string id, RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id);
                AppRole applicationRole = isExist ? await roleManager.FindByIdAsync(id) :
               new AppRole
               {
               };
                applicationRole.Name = model.RoleName;
                IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(applicationRole)
                                                    : await roleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
