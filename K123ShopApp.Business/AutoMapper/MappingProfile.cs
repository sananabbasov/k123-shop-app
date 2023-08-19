using System;
using AutoMapper;
using K123ShopApp.Core.Entities.Concrete;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.CategoryDtos;
using K123ShopApp.Entities.Dtos.OrderDtos;
using K123ShopApp.Entities.Dtos.ProductDtos;
using K123ShopApp.Entities.Dtos.SpecificationDtos;
using K123ShopApp.Entities.Dtos.UserDtos;
using K123ShopApp.Entities.Dtos.WishListDtos;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.Business.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AppUser, UserInfoDto>();
			CreateMap<UserRegisterDto, AppUser>();

			CreateMap<CategoryCreateDto, Category>();
			CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryHomeDto>();
            CreateMap<Category, CategoryNavbarDto>();


			CreateMap<Product, ProductDetailDto>();
			CreateMap<ProductUpdateDto, Product>();
			CreateMap<ProductCreateDto, Product>();

			CreateMap<Product, ProductRecentDto>();
			CreateMap<Product, ProductFilterDto>();
			CreateMap<Product, ProductFeaturedDto>();
			CreateMap<Product, ProductDto>();

			CreateMap<SpecificationCreateDto, Specification>();
			CreateMap<Specification, SpecificationListDto>();

			CreateMap<UserWishListDto, AppUser>().ReverseMap();
			CreateMap<WishList, WishListItemDto>()
				.ForMember(x=>x.ProductName, o=>o.MapFrom(s=>s.Product.ProductName))
				.ForMember(x=>x.Price, o=>o.MapFrom(s=>s.Product.Price));

			CreateMap<WishListAddItemDto, WishList>();


			CreateMap<OrderCreateDto, Order>();

			CreateMap<AppUser, UserOrderDto>();
        

			CreateMap<Order, OrderUserDto>()
						.ForMember(x => x.ProductName, o => o.MapFrom(x => x.Product.ProductName))
						.ForMember(x => x.OrderEnum, o => o.MapFrom(x => Enum.GetName(x.OrderEnum)));
        }
    }
}

