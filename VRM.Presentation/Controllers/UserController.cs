using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
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

namespace VRM.Presentation.Controllers
{
    public class UserController : Controller
    {
        //private readonly IAccount _service;
        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<User> _signInManager;


        //public UserController(IAccount service,, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        //{
        //    _service = service;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _signInManager = signInManager;
        //}
            private readonly UserManager<User> userManager;
            private readonly RoleManager<AppRole> roleManager;

            public UserController(UserManager<User> userManager, RoleManager<AppRole> roleManager)
            {
                this.userManager = userManager;
                this.roleManager = roleManager;
            }

            public IActionResult Index()
            {
                List<UserListViewModel> model = new List<UserListViewModel>();
                model = userManager.Users.Select(u => new UserListViewModel
                {
                    Id = u.Id,
                    Email = u.Email
                }).ToList();
                return View(model);
            }


            public IActionResult Create()
            {
                UserViewModel model = new UserViewModel();
                model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
                }).ToList();
                return View(nameof(Create), model);
            }

            [HttpPost]
            public async Task<IActionResult> Create(UserViewModel model)
            {
                User user = new User
                {
                    UserName = model.Email,
                    Email = model.Email
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

                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Edit(string id)
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
                        model.Email = user.Email;
                        model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                    }
                }
                return View(nameof(Edit), model);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(string id, EditUserViewModel model)
            {
            User user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
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
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }

                    }
                }
                return View(nameof(Edit), model);
            }

            [HttpGet]
            public async Task<IActionResult> Delete(string id)
            {
                string name = string.Empty;
                if (!String.IsNullOrEmpty(id))
                {
                User applicationUser = await userManager.FindByIdAsync(id);
                    if (applicationUser != null)
                    {
                        name = applicationUser.Email;
                    }
                }
                return View(nameof(Delete), name);
            }

            [HttpPost]
            [ActionName("Delete")]
            public async Task<IActionResult> DeletePOST(string id)
            {
                if (!String.IsNullOrEmpty(id))
                {
                User applicationUser = await userManager.FindByIdAsync(id);
                    if (applicationUser != null)
                    {
                        IdentityResult result = await userManager.DeleteAsync(applicationUser);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View();
            }
        }
}