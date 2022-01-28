using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetById(id);            
            return View(product.ToProductViewModel());
        }
    }
}
