using System;
using K123ShopApp.Core.Configurations;
using K123ShopApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        // CreateDate = DateTime.Now
    }
}

