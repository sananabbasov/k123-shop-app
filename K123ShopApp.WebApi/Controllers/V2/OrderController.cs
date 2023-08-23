using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.OrderDtos;
using K123ShopApp.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAppUserService _appUserService;
        public OrderController(IOrderService orderService, IAppUserService appUserService)
        {
            _orderService = orderService;
            _appUserService = appUserService;
        }

        [Authorize]
        [HttpPost("create")]
        [MapToApiVersion("2.0")]
        public IActionResult OrderProduct([FromBody]List<OrderCreateDto> orderCreate)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var res =_orderService.CreateOrder(userId, orderCreate);

            return Ok(res);
        }

        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpGet("userorder")]
        public IActionResult OrderUser()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var userOrder = _appUserService.GetUserOrders(userId);
            return Ok(userOrder);
        }

        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpGet("get/{ordernumber}")]
        public IActionResult OrderUser(string ordernumber)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [Authorize(Roles = "Moderator")]
        [HttpPut("status/{orderNumber}")]
        public IActionResult OrderChangeStatus(string orderNumber,[FromBody] OrderEnum order)
        {
            var res = _orderService.ChangeOrderStatus(orderNumber, order);
            return Ok(res);
        }


    }
}

