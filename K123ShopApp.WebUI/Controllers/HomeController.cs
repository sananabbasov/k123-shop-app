using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using K123ShopApp.WebUI.Models;
using K123ShopApp.Business.Abstract;
using K123ShopApp.WebUI.ViewModels;
using K123ShopApp.WebUI.Attributes;

namespace K123ShopApp.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        
        HomeVM vm = new()
        {
            ProductRecent = _productService.GetRecentProduct().Data,
            ProductFeatured = _productService.GetFeaturedProducts().Data,
            HomeCategories= _categoryService.GetHomeCagories().Data
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

