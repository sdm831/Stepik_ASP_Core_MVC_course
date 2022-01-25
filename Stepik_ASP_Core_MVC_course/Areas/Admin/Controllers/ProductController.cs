﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;        

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;        
        }
        
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();                        
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);                        
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Add(productDb);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            return View(productsRepository.TryGetById(productId));
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Update(productDb);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Remove(int productId)
        //{
        //    productsRepository.RemoveProduct(productId);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
