using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        

        public HomeController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;            
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }
    }
}
