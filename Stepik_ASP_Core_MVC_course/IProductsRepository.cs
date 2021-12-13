using Stepik_ASP_Core_MVC_course.Models;
using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void Add(Product product);
        void Update(Product product);
        void RemoveProduct(int productId);
    }
}