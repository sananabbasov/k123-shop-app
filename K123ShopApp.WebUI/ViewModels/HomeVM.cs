using System;
using K123ShopApp.Entities.Dtos.CategoryDtos;
using K123ShopApp.Entities.Dtos.ProductDtos;

namespace K123ShopApp.WebUI.ViewModels
{
	public class HomeVM
	{
		public List<ProductFeaturedDto> ProductFeatured { get; set; }
		public List<ProductRecentDto> ProductRecent { get; set; }
		public List<CategoryHomeDto> HomeCategories { get; set; }
	}
}

