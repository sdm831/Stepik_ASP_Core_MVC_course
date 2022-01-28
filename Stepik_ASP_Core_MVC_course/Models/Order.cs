using System;
using System.Collections.Generic;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        
        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }
        
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
