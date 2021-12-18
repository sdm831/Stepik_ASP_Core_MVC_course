using Stepik_ASP_Core_MVC_course.Areas.Admin.Models;
using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Add(Role role);
        void Remove(string name);
        
    }
}