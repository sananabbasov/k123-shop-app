using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.UserDtos;

namespace K123ShopApp.Business.Abstract
{
	public interface IAppUserService
	{
		IResult LoginUser(UserLoginDto userLogin);
        Task<IResult> Register(UserRegisterDto userRegister);
		IResult VerifyEmail(string email, string verifyToken);
        IDataResult<UserInfoDto> GetUserInfo(int id);
		IDataResult<UserOrderDto> GetUserOrders(int id);
		IDataResult<UserWishListDto> GetUserWishListById(int id);
	}
}

