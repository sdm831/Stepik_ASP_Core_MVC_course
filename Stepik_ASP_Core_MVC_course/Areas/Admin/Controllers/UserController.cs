using Microsoft.AspNetCore.Mvc;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {     
        public IActionResult Index()
        {
            return View();
        }
    }
}
