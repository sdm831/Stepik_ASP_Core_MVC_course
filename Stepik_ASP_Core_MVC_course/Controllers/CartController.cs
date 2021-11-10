using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }
        
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(UsersRepository.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            cartsRepository.Add(product, UsersRepository.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            cartsRepository.DecreaseAmount(product, UsersRepository.UserId);
            return RedirectToAction("Index");
        }
        

    }
}
