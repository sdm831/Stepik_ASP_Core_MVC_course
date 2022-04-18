using OnlineShop.db.Models;
using System;

namespace OnlineShop.db
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void DecreaseAmount(Guid productId, string userId);
        //void DelItem(Guid productId, string userId);
        void Clear(string userId);
    }
}