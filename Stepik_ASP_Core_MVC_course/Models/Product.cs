using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Product
    {
        public static List<Product> products = new List<Product>()
        {
            new Product(01, "cement", 300, "Лучший цемент.") { },
            new Product(02, "kraska", 800, "Яркая краска.") { },
            new Product(03, "lak", 500, "Прозрачный лак.") { }
        };
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public Product(int id, string name, int cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}
