using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            _userManager = userManager;
            _signInManager = signInManager;
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
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    //return login.ReturnUrl != null ? Redirect(login.ReturnUrl) : View("/home/index");

                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }

                return View(login);
            }

            var userAccount = usersManager.TryGetByName(login.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return RedirectToAction(nameof(login));
            }

            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Неправильный пароль!");
                return RedirectToAction(nameof(login));
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
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
                User user = new User() { Email = register.UserName, UserName = register.UserName };

                var result = _userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    //установка куки
                    _signInManager.SignInAsync(user, false).Wait();

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

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();

            var t1 = nameof(HomeController);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            //return RedirectToAction(nameof(HomeController));
        }
    }
}
