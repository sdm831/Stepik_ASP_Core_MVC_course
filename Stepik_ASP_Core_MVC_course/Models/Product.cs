using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Product
    {
        
        
        private static int idGenerator = 1;

        public int ProductId { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string ImagePath { get; }
        public Product(string name, int cost, string description, string imagePath)
        {
            ProductId = idGenerator;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;

            idGenerator += 1;
        }

        public override string ToString()
        {
            return $"{ProductId}\n{Name}\n{Cost}";
        }
    }
}
