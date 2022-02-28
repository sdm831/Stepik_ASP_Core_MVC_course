using OnlineShop.db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.db
{
    public class DbRepositoryRoles : IRolesRepository
    {
        private readonly DatabaseContext databaseContext;

        public DbRepositoryRoles(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        
        public RoleDb TryGetByName(string name)
        {
            return databaseContext.Roles.FirstOrDefault(x => x.Name == name);
        }        

        public List<RoleDb> GetAll()
        {
            var roles = databaseContext.Roles.ToList();
            return roles;
        }
        
        public void Add(RoleDb role)
        {
            databaseContext.Roles.Add(role);
            databaseContext.SaveChanges();            
        }

        public void Remove(string name)
        {
            var role = databaseContext.Roles.FirstOrDefault(x => x.Name == name);
            databaseContext.Roles.Remove(role);
            databaseContext.SaveChanges();
        }
    }
}
