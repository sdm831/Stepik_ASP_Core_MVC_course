using OnlineShop.db.Models;
using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(product.ToProductViewModel());
            }

            return productsViewModels;
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if(cart == null)
            {
                return null;
            }
            
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.ToCartItemViewModels()
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();

            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product.ToProductViewModel()
                };
                cartItems.Add(cartItem);
            }
            
            return cartItems;
        }
    }
}
