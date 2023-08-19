using System;
using K123ShopApp.Core.Entities.Abstract;

namespace K123ShopApp.Entities.Concrete
{
	public class Specification : BaseEntity, IEntity
    {
		public string Key { get; set; }
		public string Value { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}

