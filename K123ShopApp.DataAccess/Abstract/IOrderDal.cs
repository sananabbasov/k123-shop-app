using System;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.OrderDtos;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface IOrderDal : IRepositoryBase<Order>
    {
		void AddRange(int userId, List<Order> orders);
	}
}

