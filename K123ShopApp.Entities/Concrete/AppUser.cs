using System;
using K123ShopApp.Core.Entities.Abstract;
using K123ShopApp.Core.Entities.Concrete;

namespace K123ShopApp.Entities.Concrete
{
	public class AppUser : User, IEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<Order> Orders { get; set; }
	}
}

