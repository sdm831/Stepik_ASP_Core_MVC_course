using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    [Authorize]
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
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);            
            return View(Mapping.ToCartViewModel(cart));            
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            cartsRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        
        //public IActionResult DelItem(Guid productId)
        //{
        //    cartsRepository.DelItem(productId, Constants.UserId);
        //    return RedirectToAction("Index");
        //}

        public IActionResult ClearCart()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
