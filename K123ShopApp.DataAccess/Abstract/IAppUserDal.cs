using System;
using System.Linq.Expressions;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Core.Entities.Concrete;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface IAppUserDal : IRepositoryBase<AppUser>
    {
        AppUser GetUserOrders(int userId);
    }
}

