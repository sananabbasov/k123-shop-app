using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.OrderDtos;
using K123ShopApp.Entities.Dtos.UserDtos;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.Business.Abstract
{
	public interface IOrderService
	{
		IResult CreateOrder(int userId, List<OrderCreateDto> orderCreate);
		IResult ChangeOrderStatus(string orderNumber, OrderEnum orderStatus);
		IDataResult<UserOrderDto> GetUserOrderById(int userId);
		IDataResult<OrderUserDto> GetOrderStatusByProductId(int userId, int productId);
	}
}

