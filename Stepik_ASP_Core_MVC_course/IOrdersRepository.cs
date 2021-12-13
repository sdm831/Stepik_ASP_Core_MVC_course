using Stepik_ASP_Core_MVC_course.Models;
using System;
using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}