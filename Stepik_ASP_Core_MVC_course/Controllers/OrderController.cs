using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Buy()
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.ClearCart(Constants.UserId);
            return View();
        }
    }
}
