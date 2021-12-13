using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Product
    {        
        private static int instanceCounter = 1;

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        
        public Product()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public Product(string name, decimal cost, string description, string imagePath) : this()
        {
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
