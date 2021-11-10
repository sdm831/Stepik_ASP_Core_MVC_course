using Stepik_ASP_Core_MVC_course.Models;

namespace Stepik_ASP_Core_MVC_course
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(object product, string userId);
    }
}