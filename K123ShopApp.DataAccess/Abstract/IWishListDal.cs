using System;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface IWishListDal : IRepositoryBase<WishList>
    {
        List<WishList> GetUserWishList(int id);
    }
}

