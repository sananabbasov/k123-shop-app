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

namespace K123ShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

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

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDto productUpdate)
        {
            var result = _productService.UpdateProduct(productUpdate);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProdcuts();
            return Ok(result);
        }

        [HttpGet("featured")]
        public IActionResult GetFeaturedProducts()
        {
            var result = _productService.GetFeaturedProducts();
            return Ok(result);
        }

        [HttpGet("recent")]
        public IActionResult GetRecentProducts()
        {
            var result = _productService.GetRecentProduct();
            return Ok(result);
        }

        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] int categoryId, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var result = _productService.FilterProduct(categoryId, minPrice, maxPrice);
            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var result = _productService.RemoveProduct(id);
            return Ok(result);
        }
    }
}

