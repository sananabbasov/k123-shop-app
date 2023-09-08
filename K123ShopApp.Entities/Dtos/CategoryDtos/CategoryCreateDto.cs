using System;
namespace K123ShopApp.Entities.Dtos.CategoryDtos
{
	public class CategoryCreateDto
	{
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; }
        public bool IsNavbar { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
    }
}

