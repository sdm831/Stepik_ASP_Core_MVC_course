using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;

namespace Stepik_ASP_Core_MVC_course.Views.Shared.Components.Cart
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartCountViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = Mapping.ToCartViewModel(cart);

            var productCounts = cartViewModel?.Amount ?? 0;

            return View("CartCount", productCounts);
        }
    }
}
