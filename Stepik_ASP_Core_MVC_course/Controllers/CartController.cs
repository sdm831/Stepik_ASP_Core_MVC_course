using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productRepository;

        public CartController()
        {
            productRepository = new ProductsRepository();
        }

        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(UsersRepository.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CartsRepository.Add(product);
            return RedirectToAction("Index");
        }
    }
}
