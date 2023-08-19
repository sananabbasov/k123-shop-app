using System;
using System.Collections.Generic;
using AutoMapper;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.WishListDtos;

namespace K123ShopApp.Business.Concrete
{
    public class WishListManager : IWishListService
    {
        private readonly IWishListDal _wishListDal;
        private readonly IMapper _mapper;
        public WishListManager(IWishListDal wishListDal, IMapper mapper)
        {
            _wishListDal = wishListDal;
            _mapper = mapper;
        }

        public IResult AddWishList(int userId, WishListAddItemDto addItem)
        {
            var map = _mapper.Map<WishList>(addItem);
            map.CreatedDate = DateTime.Now;
            map.AppUserId = userId;
            _wishListDal.Add(map);
            return new SuccessResult();
        }

        public IDataResult<List<WishListItemDto>> GetUserWishList(int id)
        {
            var list = _wishListDal.GetUserWishList(id);
            if (!list.Any())
            {
                List<WishListItemDto> emptyList = new();
                return new ErrorDataResult<List<WishListItemDto>>(emptyList);
            }
            var mapList = _mapper.Map<List<WishListItemDto>>(list);
            return new SuccessDataResult<List<WishListItemDto>>(mapList);
        }
    }
}

