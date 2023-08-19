using System;
using K123ShopApp.Entities.Dtos.WishListDtos;

namespace K123ShopApp.Entities.Dtos.UserDtos
{
	public class UserWishListDto
	{
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<WishListItemDto> WishLists { get; set; }
    }
}

