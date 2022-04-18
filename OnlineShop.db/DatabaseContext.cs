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
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }

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
                .HasForeignKey(x => x.ProductId) // связь 
                .OnDelete(DeleteBehavior.Cascade);

            //var product1Id = new Guid();
            var product1Id = Guid.Parse("aa11aaa1-11a1-1a11-111a-11a1aaa11a11");

            //var product2Id = new Guid();
            var product2Id = Guid.Parse("aa22aaa2-22a2-2a22-222a-22a2aaa22a22");

            var image1 = new Image
            {
                //Id = new Guid(),
                Id = Guid.Parse("aa33aaa3-33a3-3a33-333a-33a3aaa33a33"),
                Url = "/images/Products/box.jpg",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                //Id = new Guid(),
                Id = Guid.Parse("aa44aaa4-44a4-4a44-444a-44a4aaa44a44"),
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
