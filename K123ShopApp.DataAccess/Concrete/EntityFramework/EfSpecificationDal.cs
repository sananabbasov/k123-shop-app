using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfSpecificationDal : EfRepositoryBase<Specification, AppDbContext>, ISpecificationDal
    {
        public void AddSpecifications(int productId, List<Specification> specifications)
        {
            using var context = new AppDbContext();
            List<Specification> res = specifications.Select(x => { x.ProductId = productId; x.CreatedDate = DateTime.Now; return x; }).ToList();

            context.Specifications.AddRange(res);
            context.SaveChanges();
        }
    }
}

