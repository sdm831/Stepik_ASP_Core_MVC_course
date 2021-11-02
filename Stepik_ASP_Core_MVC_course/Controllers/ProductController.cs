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

        public string Index(int id)
        {
            var product = productRepository.TryGetById(id);

            if (product == null)
            {
                return $"Продукта с id={id} не обнаружено!";
            }
            else
            {
                return $"{product}\n{product.Description}";
            }
        }
    }
}
