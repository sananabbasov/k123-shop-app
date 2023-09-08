using System;
using K123ShopApp.Entities.Dtos.ProductDtos;
using K123ShopApp.Entities.Dtos.UserDtos;

namespace K123ShopApp.WebUI.ViewModels
{
	public class OrderVM
	{
		public List<ProductDetailDto> ProductDetails { get; set; }
		public UserInfoDto UserInfo { get; set; }
	}
}

