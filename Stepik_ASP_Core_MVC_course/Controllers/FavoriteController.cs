using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;
using System;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductsRepository productsRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductsRepository productsRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(Constants.UserId);
            return View(Mapping.ToProductViewModels(products));
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            if(product != null)
            {
                favoriteRepository.Add(Constants.UserId, product);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            favoriteRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
