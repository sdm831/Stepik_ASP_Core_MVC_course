using Microsoft.AspNetCore.Mvc;
using Stepik_ASP_Core_MVC_course.Models;

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
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productsRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int productId)
        {
            return View(productsRepository.TryGetById(productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            productsRepository.RemoveProduct(productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
