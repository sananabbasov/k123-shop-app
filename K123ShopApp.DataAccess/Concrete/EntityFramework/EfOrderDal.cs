using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public void AddRange(int userId, List<Order> orders)
        {
            using var context = new AppDbContext();
            var res = orders.Select(x => { x.AppUserId = userId; x.CreatedDate = DateTime.Now; x.OrderNumber = Guid.NewGuid().ToString().Substring(0, 18); x.OrderEnum = OrderEnum.OnPending; return x; }).ToList();
            context.AddRangeAsync(res);
            context.SaveChanges();
        }
    }
}

