using OnlineShop.db.Models;
using System.Collections.Generic;

namespace OnlineShop.db
{
    public interface IRolesRepository
    {
        List<RoleDb> GetAll();
        RoleDb TryGetByName(string name);
        void Add(RoleDb role);
        void Remove(string name);
    }
}