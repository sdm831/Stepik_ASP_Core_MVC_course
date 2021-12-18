using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("cement",  300, "Лучший цемент.",  "/images/cement.jpg") { },
            new Product("kraska",  800, "Яркая краска.",   "/images/kraska.jpg") { },
            new Product("lak",     500, "Прозрачный лак.", "/images/lak.jpg") { },
            new Product("dsp",     600, "Ровный ДСП.",     "/images/dsp.jpg") { },
            new Product("shpatel", 200, "Ровный шпатель.", "/images/shpatel.jpg") { }
        };

        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {            
            product.ImagePath = "https://static9.depositphotos.com/1674252/1149/v/950/depositphotos_11495781-stock-illustration-wavy-new-sign.jpg";
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if(existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            //existingProduct.ImagePath = product.ImagePath;
        }

        public void RemoveProduct(int productId)
        {
            products.Remove(products.FirstOrDefault(p => p.Id == productId));
        }
    }
}
