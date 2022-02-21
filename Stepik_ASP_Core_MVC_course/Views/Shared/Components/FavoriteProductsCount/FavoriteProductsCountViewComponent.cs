using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course.Views.Shared.Components.Cart
{
    public class FavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;

        public FavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteRepository.GetAll(Constants.UserId).Count();
            return View("FavoriteProductsCount", productsCount);
        }
    }
}
