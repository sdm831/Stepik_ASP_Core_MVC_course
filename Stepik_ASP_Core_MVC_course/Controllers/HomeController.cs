using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Models;
using System.Collections.Generic;

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
            var products = productRepository.GetAll();
            var productsViewModels = new List<ProductViewModel>();

            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);
        }      
    }
}
