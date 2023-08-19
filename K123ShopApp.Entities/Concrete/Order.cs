using System;
using K123ShopApp.Core.Entities.Abstract;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.Entities.Concrete
{
	public class Order : BaseEntity, IEntity
    {
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
        public string DeliveryAddress { get; set; }
		public OrderEnum OrderEnum { get; set; }
		public string OrderNumber { get; set; }
	}
}

