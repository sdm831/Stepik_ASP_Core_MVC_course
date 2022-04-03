using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;
using System;
using System.Collections.Generic;

// migration
// Add-Migration add_images -Context DatabaseContext -OutputDir Migrations/Data

namespace OnlineShop.db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }
        
        
        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<RoleDb> Roles { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.Product.Id) // связь 
                .OnDelete(DeleteBehavior.Cascade);

            var product1Id = new Guid();
            var product2Id = new Guid();

            var image1 = new Image
            {
                Id = new Guid(),
                Url = "/images/Products/box.jpg",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                Id = new Guid(),
                Url = "/images/Products/box.jpg",
                ProductId = product2Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id, "Name1", 10, "Desc1"),
                new Product(product2Id, "Name2", 20, "Desc2")
            });
        }
    }
}
