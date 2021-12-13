using Stepik_ASP_Core_MVC_course.Models;
using System.Collections.Generic;
using System.Linq;

namespace Stepik_ASP_Core_MVC_course
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>();

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(r => r.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(r => r.Name == name);
        }
    }
}