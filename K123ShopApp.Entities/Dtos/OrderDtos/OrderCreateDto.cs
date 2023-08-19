using System;

namespace K123ShopApp.Entities.Dtos.OrderDtos
{
	public class OrderCreateDto
	{
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string DeliveryAddress { get; set; }
    }
}

