using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {            
            return View(usersManager.GetAll());
        }

        public IActionResult Detail(string name)
        {
            var v = usersManager.TryGetByName(name);
            return View(usersManager.TryGetByName(name));
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
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
