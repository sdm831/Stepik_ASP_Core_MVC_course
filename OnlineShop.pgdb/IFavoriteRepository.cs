using OnlineShop.db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.db
{
    public interface IFavoriteRepository
    {
        List<Product> GetAll(string userId);
        void Add(string userId, Product product);
        void Clear(string userId);
        void Remove(string userId, Guid productId);
    }
}