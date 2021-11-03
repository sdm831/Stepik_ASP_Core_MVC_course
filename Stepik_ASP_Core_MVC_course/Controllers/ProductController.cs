using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            //var product = productRepository.TryGetById(id);
            var products = productRepository.GetAll();

            //if (product == null)
            //{
            //    return $"Продукта с id={id} не обнаружено!";
            //}
            //else
            //{
            //    return $"{product}\n{product.Description}";
            //}

            return View(products);
        }
    }
}
