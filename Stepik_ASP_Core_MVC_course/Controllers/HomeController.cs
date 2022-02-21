using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;


        public HomeController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            try
            {
                var products = productRepository.GetAll();                
                return View(Mapping.ToProductViewModels(products));
            }
            catch (Exception e)
            {
                throw;
            }            
        }      
    }
}
