using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = _productService.GetProductById(id).Data;
            return View(product);
        }
    }
}

