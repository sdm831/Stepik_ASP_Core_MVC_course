using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository = null)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View(ordersRepository.GetAll());
        }

        public IActionResult Detail(Guid orderId)
        {
            return View(ordersRepository.TryGetById(orderId));
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
