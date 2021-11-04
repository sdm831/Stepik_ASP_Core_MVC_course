using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
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
        internal Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.ProductId == id);
        }
    }
}
