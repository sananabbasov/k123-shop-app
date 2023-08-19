using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public Product GetProduct(int id)
        {
            using var context = new AppDbContext();
            var product = context.Products.Include(x => x.Category).Include(x => x.Specifications).SingleOrDefault(x => x.Id == id);
            return product;
        }

        public void RemoveProductQuantity(List<int> productId, List<int> quantity)
        {
            using var context = new AppDbContext();
            var products = context.Products
                .Where(x => productId.Contains(x.Id)).ToList();

            for (int i = 0; i < productId.Count; i++)
            {
                products.Select(x => { x.Quantity -= quantity[i]; return x; }).ToList();
            }

            context.Products.UpdateRange(products);
            context.SaveChanges();

        }
    }
}

