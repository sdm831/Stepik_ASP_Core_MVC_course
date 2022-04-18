using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.db
{
    public class DbRepositoryProducts : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public DbRepositoryProducts(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
        {
            //product.ImagePath = "https://static9.depositphotos.com/1674252/1149/v/950/depositphotos_11495781-stock-illustration-wavy-new-sign.jpg";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {            
            return databaseContext.Products
                .Include(x => x.Images)
                //.Include(x => x.CartItems)
                //.ThenInclude(x => x.Product)
                .ToList();
        }
        public Product TryGetById(Guid id)
        {
            //return databaseContext.Products.FirstOrDefault(p => p.Id == id);
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;

            //var existingUrls = existingProduct.Images.Select(x => x.Url).ToList();

            foreach (var image in product.Images)
            {
                image.ProductId = product.Id;
                databaseContext.Images.Add(image);
            }

            databaseContext.SaveChanges();
        }

        public void RemoveProduct(Guid productId)
        {
            var product = TryGetById(productId);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }
    }
}
