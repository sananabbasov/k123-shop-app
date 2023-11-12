using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [MapToApiVersion("2.0")]
        [Authorize(Roles = "Admin,User")]
        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productCreate)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var result = _productService.CreateProduct(productCreate);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDto productUpdate)
        {
            var result = _productService.UpdateProduct(productUpdate);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("get/{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("getall")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProdcuts(1);
            return Ok(result.Data);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("featured")]
        public IActionResult GetFeaturedProducts()
        {
            var result = _productService.GetFeaturedProducts();
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("recent")]
        public IActionResult GetRecentProducts()
        {
            var result = _productService.GetRecentProduct();
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] int categoryId, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var result = _productService.FilterProduct(categoryId, minPrice, maxPrice);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("delete/{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var result = _productService.RemoveProduct(id);
            return Ok(result);
        }
    }
}

