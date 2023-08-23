using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    // sitename.com/api/user/register
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("Login")]
        public IActionResult UserLogin([FromBody]UserLoginDto userLogin)
        {
            var result = _appUserService.LoginUser(userLogin);
            return Ok(result);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto userRegister)
        {
            var result = await _appUserService.Register(userRegister);
            return Ok(result);
        }

        // sitename/api/user?email=ehmed@comapar.edu.az&token=skjdf-sdfa-sdfsd-fsdf
        [HttpGet("VerifyEmail")]
        public IActionResult VerifyEmail([FromQuery]string email, [FromQuery] string token)
        {
            var result = _appUserService.VerifyEmail(email, token);
            return Ok(result);
        }



        
    }
}

