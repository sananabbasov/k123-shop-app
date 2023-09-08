using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.CartDtos;
using K123ShopApp.Entities.Dtos.OrderDtos;
using K123ShopApp.WebUI.Attributes;
using K123ShopApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IAppUserService _appUserService;
        public OrderController(IProductService productService, IOrderService orderService, IAppUserService appUserService)
        {
            _productService = productService;
            _orderService = orderService;
            _appUserService = appUserService;
        }

        [CustomAuthorize("User")]
        public IActionResult Index()
        {
            return View();
        }


        public JsonResult AddToCart(string Id, int Quantity)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            CartItemDto cartItemDTO = new()
            {
                Id = Id,
                Quantity = Quantity
            };
            var cookie = Request.Cookies["products"];
            if (cookie == null)
            {
                List<CartItemDto> cartItems = new();
                cartItems.Add(cartItemDTO);
                var result = JsonSerializer.Serialize<List<CartItemDto>>(cartItems);

                Response.Cookies.Append("products", result, cookieOptions);
            }
            else
            {
                var datas = JsonSerializer.Deserialize<List<CartItemDto>>(cookie);

                var pro = datas.FirstOrDefault(x => x.Id == Id);
                if (pro != null)
                {
                    pro.Quantity += Quantity;
                }
                else
                {
                    datas.Add(cartItemDTO);
                }

                var updatedDate = JsonSerializer.Serialize<List<CartItemDto>>(datas);
                Response.Cookies.Append("products", updatedDate, cookieOptions);

            }
            return Json("Ok");
        }

        public IActionResult Basket()
        {
            var cookie = Request.Cookies["products"];
            if (cookie != null)
            {
                var datas = JsonSerializer.Deserialize<List<CartItemDto>>(cookie);
                var product = _productService.GetProductsById(datas);
                return View(product.Data);
            }

            return View();
        }

        [CustomAuthorize("User")]
        public IActionResult PlaceOrder()
        {
            var cookiee = Request.Cookies["token"];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityTokens = handler.ReadJwtToken(cookiee);
            var userId = jwtSecurityTokens.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;
            int convertId = Convert.ToInt32(userId);
            var user = _appUserService.GetUserInfo(convertId);
            var cookie = Request.Cookies["products"];
            if (cookie != null)
            {
                var datas = JsonSerializer.Deserialize<List<CartItemDto>>(cookie);
                var product = _productService.GetProductsById(datas);

                OrderVM vm = new()
                {
                    ProductDetails = product.Data,
                    UserInfo = user.Data
                };
                return View(vm);
            }

            return View();
        }

        [HttpPost]
        [CustomAuthorize("User")]
        public IActionResult PlaceOrder(string DeliveryAddress)
        {
            var cookie = Request.Cookies["token"];
            var cookiee = Request.Cookies["products"];



            var datas = JsonSerializer.Deserialize<List<CartItemDto>>(cookiee);
            var product = _productService.GetProductsById(datas);
            List<OrderCreateDto> orders = new();
            foreach (var item in product.Data)
            {
                OrderCreateDto newOrder = new()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    DeliveryAddress = DeliveryAddress,
                    ProductId = item.Id
                };
                orders.Add(newOrder);
            }


            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityTokens = handler.ReadJwtToken(cookie);
            var userId = jwtSecurityTokens.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;
            int convertId = Convert.ToInt32(userId);
            _orderService.CreateOrder(convertId, orders);
            return RedirectToAction("Index", "Home");
        }
    }
}

