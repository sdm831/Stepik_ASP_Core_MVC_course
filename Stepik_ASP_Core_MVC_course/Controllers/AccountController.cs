using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Models;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserDb> userManager;
        private readonly SignInManager<UserDb> signInManager;

        public AccountController(UserManager<UserDb> userManager, SignInManager<UserDb> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }

            return View(login);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl});
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
                UserDb user = new UserDb() { Email = register.UserName, UserName = register.UserName, PhoneNumber = register.Phone };

                var result = userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    //установка куки
                    signInManager.SignInAsync(user, false).Wait();

                    TryAssignUserRole(user);

                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                
                return View(register);                
            }

            return RedirectToAction(nameof(Register));
        }

        private void TryAssignUserRole(UserDb user)
        {
            try
            {
                userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                // add log
            }
        }

        public IActionResult Logout()  // SignOut() ??
        {
            signInManager.SignOutAsync().Wait();                        
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));            
        }
    }
}
