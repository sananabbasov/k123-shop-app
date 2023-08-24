using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using K123ShopApp.Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(typeof(SuccessDataResult<CategoryDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("featured")]
        [MapToApiVersion("2.0")]
        public IActionResult GetHomeFeatured()
        {
            var result = _categoryService.GetHomeCagories();
            return Ok(result);
        }


        [HttpGet("navbar")]
        [MapToApiVersion("2.0")]
        public IActionResult GetNavbarLower()
        {
            var result = _categoryService.GetNavbarCategories();
            return Ok(result);
        }

        [HttpPost("create")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryCreate)
        {
            var result = await _categoryService.CreateCategoryAsync(categoryCreate);
            return Ok(result);
        }

        // sitename/api/category/12
        [HttpPut("update/{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult Update(int id,[FromBody] CategoryUpdateDto categoryUpdate)
        {
            var result = _categoryService.UpdateCategory(id, categoryUpdate);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return Ok(result);
        }
    }
}

