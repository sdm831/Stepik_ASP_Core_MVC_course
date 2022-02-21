using OnlineShop.db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}