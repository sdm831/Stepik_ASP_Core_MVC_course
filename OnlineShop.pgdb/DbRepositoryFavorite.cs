using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.db
{
    public class DbRepositoryFavorite : IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;

        public DbRepositoryFavorite(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }               
                
        List<Product> IFavoriteRepository.GetAll(string userId)
        {
            return databaseContext.FavoriteProducts
                .Where(p => p.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();           
        }
        
        void IFavoriteRepository.Add(string userId, Product product)
        {
            var existingProduct = databaseContext.FavoriteProducts
                        .FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.FavoriteProducts.Add(new FavoriteProduct { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var products = databaseContext.FavoriteProducts.Where(x => x.UserId == userId);
            databaseContext.FavoriteProducts.RemoveRange(products);
            databaseContext.SaveChanges();                        
        }

        public void Remove(string userId, Guid productId)
        {
            var product = databaseContext.FavoriteProducts.FirstOrDefault(x => x.Product.Id == productId && x.UserId == userId);
            databaseContext.FavoriteProducts.Remove(product);
            databaseContext.SaveChanges();
        }
    }
}
