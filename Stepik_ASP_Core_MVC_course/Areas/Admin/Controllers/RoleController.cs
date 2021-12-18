using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository = null)
        {     
            this.rolesRepository = rolesRepository;
        }        

        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }        
        
        public IActionResult Remove(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction(nameof(Index));
        }
    }
}
