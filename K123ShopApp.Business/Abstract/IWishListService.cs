using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.WishListDtos;

namespace K123ShopApp.Business.Abstract
{
	public interface IWishListService
	{
		IDataResult<List<WishListItemDto>> GetUserWishList(int id);
		IResult AddWishList(int userId,WishListAddItemDto addItem);
	}
}

