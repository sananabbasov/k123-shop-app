using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfAppUserDal : EfRepositoryBase<AppUser, AppDbContext>, IAppUserDal
    {
        public AppUser GetUserOrders(int userId)
        {
            using var context = new AppDbContext();
            var user = context.Users.Include(x=>x.Orders).ThenInclude(x=>x.Product).FirstOrDefault(x=>x.Id == userId);
            return user;
        }
    }
}

