using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto userLogin)
        {
            var login = _appUserService.LoginUser(userLogin);
            if (login.Success)
            {
                var cookie = login.Message;
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                cookieOptions.Path = "/";
                Response.Cookies.Append("token", cookie, cookieOptions);
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegister)
        {
            var registerUser = await _appUserService.Register(userRegister);
            if (registerUser.Success)
            {
                return RedirectToAction("Login");
            }
            return View();
        }




        public IActionResult UnauthorizedView()
        {
            return View();
        }
    }
}

