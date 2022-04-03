using OnlineShop.db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.db
{
    public interface IProductsRepository
    {
        List<Product> GetAll();

        Product TryGetById(Guid id);

        void Add(Product product);

        void Update(Product product);

        void RemoveProduct(Guid productId);
    }
}