using System;
using K123ShopApp.Core.DataAccess;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.ProductDtos;

namespace K123ShopApp.DataAccess.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
    {
		Product GetProduct(int id);
		void RemoveProductQuantity(List<ProductDecrementDto> productDecrement);
	}
}

