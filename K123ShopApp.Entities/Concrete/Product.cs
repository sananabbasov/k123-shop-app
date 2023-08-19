using System;
using K123ShopApp.Core.Entities.Abstract;

namespace K123ShopApp.Entities.Concrete
{
	public class Product : BaseEntity, IEntity
	{
		public string ProductName { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public string PhotoUrl { get; set; }
		public bool IsFeatured { get; set; }
		public bool IsDeleted { get; set; }
		public List<Specification> Specifications { get; set; }
	}
}

