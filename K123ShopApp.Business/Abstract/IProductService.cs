using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.CartDtos;
using K123ShopApp.Entities.Dtos.ProductDtos;

namespace K123ShopApp.Business.Abstract
{
	public interface IProductService
	{
		IResult CreateProduct(ProductCreateDto productCreate);
		IResult UpdateProduct(ProductUpdateDto productUpdate);
		IResult RemoveProduct(int id);
		IDataResult<ProductDetailDto> GetProductById(int id);
		IDataResult<List<ProductDetailDto>> GetProductsById(List<CartItemDto> cartItems);
        IDataResult<List<ProductFeaturedDto>> GetFeaturedProducts();
		IDataResult<List<ProductRecentDto>> GetRecentProduct();
		IDataResult<List<ProductFilterDto>> FilterProduct(int categoryId, decimal minPrice, decimal maxPrice);
		IDataResult<ProductResponseDto> GetAllProdcuts(int currentPage);
		IDataResult<bool> CheckProductStock(List<int> ids);
		IResult ProductOrder(List<ProductDecrementDto> productDecrement);
	}
}

