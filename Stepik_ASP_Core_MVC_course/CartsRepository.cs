using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course
{
    public static class CartsRepository
    {
        private static List<Cart> carts = new List<Cart>();

        internal static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        internal static void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
                if(existingCart != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {

                }
            }
        }
    }
}
