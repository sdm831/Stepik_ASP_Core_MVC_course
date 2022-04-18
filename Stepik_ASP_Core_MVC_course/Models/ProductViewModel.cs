using System;
using System.ComponentModel.DataAnnotations;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "Цена должна быть от 1 до 1 000 000 руб.")]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        public string[] ImagesPaths { get; set; }

        public string ImagePath => ImagesPaths.Length == 0 ? "/images/Products/box.jpg" : ImagesPaths[0];
    }
}
