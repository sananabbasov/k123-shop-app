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

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified :
                        data.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        data.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}

