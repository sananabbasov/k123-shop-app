using System;
using K123ShopApp.Core.Entities.Abstract;

namespace K123ShopApp.Entities.Concrete
{
	public class WishList : BaseEntity, IEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

