using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
