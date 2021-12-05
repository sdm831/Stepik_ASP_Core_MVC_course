﻿using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Models;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if(register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Register");
        }
    }
}
