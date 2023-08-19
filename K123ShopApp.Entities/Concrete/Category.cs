using System;
using K123ShopApp.Core.Entities.Abstract;

namespace K123ShopApp.Entities.Concrete
{
	public class Category : BaseEntity, IEntity
	{
		public string CategoryName { get; set; }
		public string PhotoUrl { get; set; }
		public bool IsNavbar { get; set; }
		public bool IsFeatured { get; set; }
		public bool IsDeleted { get; set; }
	}
}

