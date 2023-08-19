using System;
namespace K123ShopApp.Entities.Concrete
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

