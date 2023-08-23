using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.WishListDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WishListController : ControllerBase
    {

        private readonly IWishListService _wishListService;
        private readonly IAppUserService _appUserService;

        public WishListController(IWishListService wishListService, IAppUserService appUserService)
        {
            _wishListService = wishListService;
            _appUserService = appUserService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost("add")]
        public IActionResult Add([FromQuery] WishListAddItemDto wishListAdd)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var result =_wishListService.AddWishList(userId,wishListAdd);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("items")]
        public IActionResult GetUserWishList()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var result = _appUserService.GetUserWishListById(userId);

            return Ok(result);
        }
    }
}

