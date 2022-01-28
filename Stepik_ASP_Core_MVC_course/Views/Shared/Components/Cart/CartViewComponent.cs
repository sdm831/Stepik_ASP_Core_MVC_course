using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using Stepik_ASP_Core_MVC_course.Helpers;

namespace Stepik_ASP_Core_MVC_course.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = cart.ToCartViewModel();

            var productCounts = cartViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
