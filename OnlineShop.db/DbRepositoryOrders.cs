using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.db
{
    public class DbRepositoryOrders : IOrdersRepository
    {

        private readonly DatabaseContext databaseContext;

        public DbRepositoryOrders(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.ToList();
        }

        public Order TryGetById(Guid id)
        {
            return databaseContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                databaseContext.Orders.Update(order);
                databaseContext.SaveChanges();
            }
        }
    }
}
