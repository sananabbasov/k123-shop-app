using System;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.Entities.Dtos.OrderDtos
{
	public class OrderUserDto
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public string OrderEnum { get; set; }
	}
}

