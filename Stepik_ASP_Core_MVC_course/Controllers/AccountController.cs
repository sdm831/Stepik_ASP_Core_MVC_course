using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Models;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(login));
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
                usersManager.Add(new UserAccount
                {
                    Name = register.UserName,
                    Password = register.Password,
                    Phone = register.Phone
                });
                
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }

            return RedirectToAction(nameof(Register));
        }
    }
}
