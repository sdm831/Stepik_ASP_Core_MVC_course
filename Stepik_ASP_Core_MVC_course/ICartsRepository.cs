using Stepik_ASP_Core_MVC_course.Models;

namespace Stepik_ASP_Core_MVC_course
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void DecreaseAmount(int productId, string userId);
        void DelItem(int productId, string userId);
        void ClearCart(string userId);
    }
}