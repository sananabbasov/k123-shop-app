using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.CategoryDtos;

namespace K123ShopApp.Business.Abstract
{
	public interface ICategoryService
	{
		IResult CreateCategory(CategoryCreateDto categoryCreate);
		IResult UpdateCategory(int id, CategoryUpdateDto category);
		IResult DeleteCategory(int id);
		IDataResult<List<CategoryDto>> GetCategories();
		IDataResult<List<CategoryHomeDto>> GetHomeCagories();
		IDataResult<List<CategoryNavbarDto>> GetNavbarCategories();
	}
}

