using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
	public class EfCategoryDal : EfRepositoryBase<Category,AppDbContext>, ICategoryDal
	{
		
	}
}

