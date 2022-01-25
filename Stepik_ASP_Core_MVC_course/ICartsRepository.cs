using Stepik_ASP_Core_MVC_course.Models;
using System;

namespace Stepik_ASP_Core_MVC_course
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(ProductViewModel product, string userId);
        void DecreaseAmount(Guid productId, string userId);
        void DelItem(Guid productId, string userId);
        void Clear(string userId);
    }
}