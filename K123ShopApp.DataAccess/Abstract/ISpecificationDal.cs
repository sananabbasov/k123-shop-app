using System;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface ISpecificationDal : IRepositoryBase<Specification>
    {
		void AddSpecifications(int productId, List<Specification> specifications);
	}
}

