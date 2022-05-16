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
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public AdminController(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async string GetUserRole(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);
        //    var rolename = await userManager.GetRolesAsync(user);
        //    return rolename;
        //}
    }
}
