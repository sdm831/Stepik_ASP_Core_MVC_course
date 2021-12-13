using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository = null, IRolesRepository rolesRepository = null)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Orders()
        {            
            return View(ordersRepository.GetAll());
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            return View(ordersRepository.TryGetById(orderId));
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }
        

        public IActionResult Users()
        {
            return View();
        }
        
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if(rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {            
            return View(productsRepository.TryGetById(productId));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productsRepository.Update(product);
            return RedirectToAction("Products");
        }

        public IActionResult RemoveProduct(int productId)
        {
            productsRepository.RemoveProduct(productId);
            return RedirectToAction("Products");
        }
    }
}
