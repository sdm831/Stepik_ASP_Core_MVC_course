using Stepik_ASP_Core_MVC_course.Models;

namespace Stepik_ASP_Core_MVC_course
{
    public interface IOrdersRepository
    {
        void Add(Cart cart);
    }
}