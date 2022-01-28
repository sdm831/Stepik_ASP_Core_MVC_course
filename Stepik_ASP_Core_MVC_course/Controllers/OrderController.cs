using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using Stepik_ASP_Core_MVC_course.Models;

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
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);

            var existingCartViewModel = existingCart.ToCartViewModel();

            var order = new Order
            {
                User = user,
                Items = existingCartViewModel.Items
            };

            ordersRepository.Add(order);
            
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
