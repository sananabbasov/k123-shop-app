using System;
using K123ShopApp.Entities.Dtos.OrderDtos;

namespace K123ShopApp.Entities.Dtos.UserDtos
{
	public class UserOrderDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderUserDto> Orders { get; set; }
    }
}