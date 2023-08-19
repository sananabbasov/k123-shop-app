using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfWishListDal : EfRepositoryBase<WishList, AppDbContext>, IWishListDal
    {
        public List<WishList> GetUserWishList(int id)
        {
            using var context = new AppDbContext();
            var result = context.WishLists.Where(x=>x.AppUserId == id).Include(x=>x.Product).ToList();
            return result;
        }
    }
}

