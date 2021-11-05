﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductsRepository();
        }

        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetById(id);            
            return View(product);
        }
    }
}