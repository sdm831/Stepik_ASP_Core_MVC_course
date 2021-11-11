using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> orders = new List<Cart>();

        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
    }
}
