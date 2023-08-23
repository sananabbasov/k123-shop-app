using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.ProductDtos;
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

        public void RemoveProductQuantity(List<ProductDecrementDto> productDecrement)
        {
            using var context = new AppDbContext();
            for (int i = 0; i < productDecrement.Count; i++)
            {
                var product = context.Products.FirstOrDefault(x=>x.Id == productDecrement[i].ProductId);
                product.Quantity -= productDecrement[i].Quantity;
                context.SaveChanges();
            }

        }
    }
}

