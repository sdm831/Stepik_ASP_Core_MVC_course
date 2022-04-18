using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Helpers;
using Stepik_ASP_Core_MVC_course.Models;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    [Authorize]
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
            //var orders = ordersRepository.GetAll();
            //return View(orders.Select(x => Mapping.ToOrderViewModel(x)).ToList());
            return View();
        }

        //[HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);

            //var ii = existingCart.Items;

            var order = new Order
            {
                User = Mapping.ToUserDeliveryInfoDb(user),
                Items = existingCart.Items
            };

            ordersRepository.Add(order);

            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
