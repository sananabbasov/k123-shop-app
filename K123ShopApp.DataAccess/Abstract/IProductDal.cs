using System;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
    {
		Product GetProduct(int id);
		void RemoveProductQuantity(List<int> productId, List<int> quantity);
	}
}

