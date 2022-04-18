﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<UserDb> usersManager;
        private readonly RoleManager<IdentityRole> rolesManager;

        public UserController(UserManager<UserDb> usersManager, RoleManager<IdentityRole> rolesManager)
        {
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            var users = usersManager.Users.ToList();
            return View(users.Select(x => Mapping.ToUserViewModel(x)).ToList());
        }

        public IActionResult Detail(string name)
        {            
            var user = usersManager.FindByNameAsync(name).Result;
            return View(Mapping.ToUserViewModel(user));
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = usersManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                usersManager.UpdateAsync(user).Wait();
                
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult Remove(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            usersManager.DeleteAsync(user).Wait();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRights(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            var userRoles = usersManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();

            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name}).ToList()
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectedRoles = userRolesViewModel.Select(x => x.Key);

            var user = usersManager.FindByNameAsync(name).Result;
            var userRoles = usersManager.GetRolesAsync(user).Result;

            usersManager.RemoveFromRolesAsync(user, userRoles).Wait();
            usersManager.AddToRolesAsync(user, userSelectedRoles).Wait();
            
            return Redirect($"/Admin/User/Detail?name={name}");
        }
    }
}
