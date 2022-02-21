using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.db
{
    public class DbRepositoryCarts : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public DbRepositoryCarts(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            var t1 = databaseContext.Carts
                                    .Include(x => x.Items)
                                    .ThenInclude(x => x.Product);

            var t2 = t1.FirstOrDefault(x => x.UserId == userId);

            return t2;
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };
                newCart.Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }

                };
                databaseContext.Carts.Add(newCart);
            }
            
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }

            databaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);

            if (existingCartItem == null)
            {
                return;
            }

            existingCartItem.Amount--;

            if (existingCartItem.Amount == 0)
            {
                databaseContext.CartItems.Remove(existingCartItem);                
            }

            databaseContext.SaveChanges();
        }

        public void DelItem(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            databaseContext.CartItems.Remove(existingCartItem);
            databaseContext.SaveChanges();
            //existingCart.Items.Remove(existingCartItem);
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(existingCart);
            databaseContext.SaveChanges();
        }
    }
}
