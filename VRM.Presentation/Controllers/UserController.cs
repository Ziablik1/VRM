using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VRM.BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using VRM.BLL.Services;
using VRM.BLL;
using VRM.DAL.Models;
using VRM.DAL.Data;
using VRM.DAL.Repos;
using VRM.Presentation.Models;
using System.ComponentModel.DataAnnotations;

namespace VRM.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        
        private readonly UserManager<User> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                Name = u.Name,
                RoleName = "Role",
                Email = u.Email
            }).ToList();
            bool isAdmin = User
                .Identities.FirstOrDefault(i => i.AuthenticationType == "Identity.Application")
                .Claims.Any(i => i.Value == "Admin");
            ViewBag.isAdmin = isAdmin;

            return View(model);
        }
        //public async Task<IActionResult> Index(string id)
        //{
        //    List<UserListViewModel> model = new List<UserListViewModel>();
        //    User user = await userManager.FindByIdAsync(id);
        //    model = userManager.Users.Select(u => new UserListViewModel
        //    {
        //        Id = u.Id,
        //        Name = u.Name,
        //        RoleName = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).ToString(),
        //        Email = u.Email
        //    }).ToList();
        //    return View(model);
        //}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
                //if (ModelState.IsValid)
                //{

                User user = new User
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    AppRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            //}
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Name = user.Name;
                    model.Email = user.Email;
                    model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
                User user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Email = model.Email;
                    string existingRole = userManager.GetRolesAsync(user).Result.Single();
                    string existingRoleId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (existingRoleId != model.ApplicationRoleId)
                        {
                            IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
                            if (roleResult.Succeeded)
                            {
                                AppRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                    if (newRoleResult.Succeeded)
                                    {
                                        return RedirectToAction(nameof(Index));
                                    }
                                }
                            }
                        }
                    }
                }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                User applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.Name;
                }
            }
            return PartialView("_DeleteUser", name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id, IFormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                User applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}