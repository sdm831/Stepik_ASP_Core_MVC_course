using System;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public ProductViewModel Product { get; set; }

        public int Amount { get; set; }

        public decimal Cost
        {
            get
            {
                return Product.Cost * Amount;
            }
        }
    }
}
