using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Helpers;
using Stepik_ASP_Core_MVC_course.Models;
using System;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository = null)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var ordersDb = ordersRepository.GetAll();
            return View(Mapping.ToOrdersViewModel(ordersDb));
        }

        public IActionResult Detail(Guid orderId)
        {
            var orderDb = ordersRepository.TryGetById(orderId);
            var orderVM = Mapping.ToOrderViewModel(orderDb);
            return View(orderVM);
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
