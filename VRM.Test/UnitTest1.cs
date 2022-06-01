//using Xunit;
//using VRM.Presentation.Models;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using VRM.BLL.Services;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using VRM.BLL.Services;
//using VRM.BLL;
//using VRM.DAL.Models;
//using VRM.DAL.Data;
//using VRM.DAL.Repos;
//using VRM.Presentation.Models;
//using System.ComponentModel.DataAnnotations;

//namespace VRM.Test
//{
//    public class UnitTest1
//    {
//        private readonly RoleManager<AppRole> roleManager;
//        private readonly UserManager<User> userManager;

//        [Fact]
//        public void RoleNull()
//        {
//            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
//            model = roleManager.Roles.Select(r => new AppRoleListViewModel
//            {
//                RoleName = r.Name,
//                Id = r.Id,
//            }).ToList();
//            Assert.NotNull(model);
//        }

//        [Fact]
//        public void AdminRoleExist()
//        {
//            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
//            model = roleManager.Roles.Select(r => new AppRoleListViewModel
//            {
//                RoleName = r.Name,
//                Id = r.Id,
//            }).ToList();
//            var matches = model.Where(p => String.Equals(p.RoleName, "Admin", StringComparison.CurrentCulture));
//            Assert.NotNull(matches);
//        }
//        [Fact]
//        public void StudentRoleExist()
//        {
//            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
//            model = roleManager.Roles.Select(r => new AppRoleListViewModel
//            {
//                RoleName = r.Name,
//                Id = r.Id,
//            }).ToList();

//            Assert.Equal(true, model.Contains(new AppRoleListViewModel { RoleName = "Student" }));
//        }
//        [Fact]
//        public void TeacherRoleExist()
//        {
//            List<AppRoleListViewModel> model = new List<AppRoleListViewModel>();
//            model = roleManager.Roles.Select(r => new AppRoleListViewModel
//            {
//                RoleName = r.Name,
//                Id = r.Id,
//            }).ToList();

//            Assert.Equal(true, model.Contains(new AppRoleListViewModel { RoleName = "Teacher" }));
//        }
//        [Fact]
//        public void AdminUserExists()
//        {
//            List<UserListViewModel> model = new List<UserListViewModel>();
//            model = userManager.Users.Select(u => new UserListViewModel
//            {
//                Id = u.Id,
//                Name = u.Name,
//                RoleName = "Some Role",
//                Email = u.Email
//            }).ToList();

//            Assert.Equal(true, model.Contains(new UserListViewModel { Name = "Admin" }));
//        }
//        [Fact]
//        public void StudentUserExists()
//        {
//            List<UserListViewModel> model = new List<UserListViewModel>();
//            model = userManager.Users.Select(u => new UserListViewModel
//            {
//                Id = u.Id,
//                Name = u.Name,
//                RoleName = "Some Role",
//                Email = u.Email
//            }).ToList();

//            Assert.Equal(true, model.Contains(new UserListViewModel { Name = "Student1" }));
//        }

//    }
//}
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using VRM.Presentation.Controllers;

namespace VRM.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void UserIsAdmin()
        {
            var controller = getHomeControllerMocked("Admin");
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.ViewData["isAdmin"]);
            Assert.True(bool.Parse(viewResult.ViewData["isAdmin"].ToString()));
        }


        [Fact]
        public void UserIsNotAdmin()
        {
            var controller = getHomeControllerMocked("Student");
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.ViewData["isAdmin"]);
            Assert.False(bool.Parse(viewResult.ViewData["isAdmin"].ToString()));
        }


        #region private methods

        private HomeController getHomeControllerMocked(string role)
        {
            var mockLogger = new Mock<ILogger<HomeController>>();

            var mockUser = new Mock<ClaimsPrincipal>();

            IEnumerable<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, "user"),
                new Claim(ClaimTypes.Role, role)
            }.AsEnumerable();

            IEnumerable<ClaimsIdentity> identities = new List<ClaimsIdentity>() {
                new ClaimsIdentity(claims, "Identity.Application")
            }.AsEnumerable();

            mockUser.Setup(e => e.Identities).Returns(identities);

            var controller = new HomeController(mockLogger.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = mockUser.Object };

            return controller;
        }


        #endregion private methods
    }
}