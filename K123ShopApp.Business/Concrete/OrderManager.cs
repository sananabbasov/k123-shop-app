using System;
using AutoMapper;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Core.Utilities.Business;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.OrderDtos;
using K123ShopApp.Entities.Dtos.ProductDtos;
using K123ShopApp.Entities.Dtos.UserDtos;
using K123ShopApp.Entities.Enums;

namespace K123ShopApp.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDal orderDal, IMapper mapper, IProductService productService)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            _productService = productService;
        }

        public IResult ChangeOrderStatus(string orderNumber, OrderEnum orderStatus)
        {
            var order = _orderDal.Get(x => x.OrderNumber == orderNumber);
            order.OrderEnum = orderStatus;
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IResult CreateOrder(int userId, List<OrderCreateDto> orderCreate)
        {
            var productIds = orderCreate.Select(x => x.ProductId).ToList();
            var quantity = orderCreate.Select(x => x.Quantity).ToList();
            //var result = BusinessRule.CheckRules(IsProductInStock(productIds));
            var mapper = _mapper.Map<List<Order>>(orderCreate);
            _orderDal.AddRange(userId, mapper);
            var productOrder = orderCreate.Select(x => new ProductDecrementDto
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();
            _productService.ProductOrder(productOrder);
            return new SuccessResult();
        }

        public IDataResult<OrderUserDto> GetOrderStatusByProductId(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserOrderDto> GetUserOrderById(int userId)
        {
            throw new NotImplementedException();
        }

        private IResult IsProductInStock(List<int> productIds)
        {
            var product = _productService.CheckProductStock(productIds);
            if (product.Data)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
    }
}

