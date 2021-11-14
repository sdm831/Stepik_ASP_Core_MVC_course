using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Models;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.ClearCart(Constants.UserId);
            return View(existingCart.Items);
        }
    }
}
