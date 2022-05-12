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
        private readonly IMapper _mapper;
        private readonly IAccount _service;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;


        public UserController(IAccount service, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _service = service;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        //public UserController()
        //{
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAll(); // Rename -async
            var viewmodel = _mapper.Map<List<UserViewModel>>(model);
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<User>(viewModel);
                _service.Add(model);
                _service.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    var model = _service.GetById(id);
        //    var allRoles = _roleManager.Roles.ToList();
        //    var viewModel = _mapper.Map<UserViewModel>(model);
        //    var user = await _userManager.FindByIdAsync(id);

        //    foreach (var role in RolesPriority.RolesList)
        //    {
        //        if (!User.IsInRole(role) && role != RolesPriority.RolesList.Last())
        //        {
        //            var removedRole = await _roleManager.FindByNameAsync(role);
        //            allRoles.Remove(removedRole);
        //        }
        //    }

        //    viewModel.AllRoles = allRoles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name, Selected = User.IsInRole(x.Name) }).ToList();
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(UserViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByIdAsync(viewModel.Id);
        //        _mapper.Map(viewModel, user);

        //        var rolesToRemove = viewModel.AllRoles.Where(x => !x.Selected).Select(x => x.Value);
        //        var rolesToAdd = viewModel.AllRoles.Where(x => x.Selected).Select(x => x.Value);

        //        if (rolesToAdd.Count() == 0)
        //        {
        //            ModelState.AddModelError("", "Користувач має мати хоча б одну роль.");
        //            return View(viewModel);
        //        }

        //        await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
        //        await _userManager.AddToRolesAsync(user, rolesToAdd);

        //        await _userManager.UpdateAsync(user);

        //        await _signInManager.SignOutAsync();

        //        // _logger.LogInformation("User logged out."); <-- is needed?

        //        return RedirectToAction("Index");
        //    }

        //    return View(viewModel);
        //}

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var model = _service.GetById(id);
            var viewModel = _mapper.Map<UserViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, User model)
        {
            _service.Delete(id);
            _service.Save();
            return RedirectToAction("Index");
        }

    }
}