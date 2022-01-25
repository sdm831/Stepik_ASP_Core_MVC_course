using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        //private List<Product> products = new List<Product>()
        //{
        //    new Product("cement",  300, "Лучший цемент.",  "/images/cement.jpg") { },
        //    new Product("kraska",  800, "Яркая краска.",   "/images/kraska.jpg") { },
        //    new Product("lak",     500, "Прозрачный лак.", "/images/lak.jpg") { },
        //    new Product("dsp",     600, "Ровный ДСП.",     "/images/dsp.jpg") { },
        //    new Product("shpatel", 200, "Ровный шпатель.", "/images/shpatel.jpg") { }
        //};        

        public void Add(Product product)
        {
            product.ImagePath = "https://static9.depositphotos.com/1674252/1149/v/950/depositphotos_11495781-stock-illustration-wavy-new-sign.jpg";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        
        public List<Product> GetAll()
        {
            var t1 = databaseContext.Products;
            return databaseContext.Products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            databaseContext.SaveChanges();
        }

        public void RemoveProduct(Guid productId)
        {
            databaseContext.Products.Remove(databaseContext.Products.FirstOrDefault(p => p.Id == productId));
        }
    }
}
