﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
        
        public IActionResult Roles()
        {
            return View();
        }
        
        public IActionResult Products()
        {
            return View();
        }
    }
}
