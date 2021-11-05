using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository productRepository;

        public HomeController()
        {
            productRepository = new ProductsRepository();
        }
        
        public IActionResult Index()
        {            
            var products = productRepository.GetAll();                        
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
