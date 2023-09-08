using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace K123ShopApp.WebUI.Attributes
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Role { get; }

        // Replace this with your actual secret key
        private const string SecretKey = "nmDLKAna9f9WEKPPH7z3tgwnQ433FAtrdP5c9AmDnmuJp9rzwTPwJ9yUu";

        public CustomAuthorizeAttribute(string role)
        {
            Role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookie = context.HttpContext.Request.Cookies["token"];
            if (string.IsNullOrEmpty(cookie))
            {
                context.Result = new RedirectResult("/Auth/Login");
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            try
            {
                var issuer = "ComparAcademy";
                var audience = "ComparAcademy";
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    RequireExpirationTime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                };

                var jwtSecurityToken = handler.ValidateToken(cookie, tokenValidationParameters, out _);
                var jwtSecurityTokens = handler.ReadJwtToken(cookie);
                var claim = jwtSecurityTokens.Claims.FirstOrDefault(x => x.Type == "role")?.Value;

                if (claim != Role)
                {
                    context.Result = new RedirectResult("/Auth/Login");
                    return;
                }
            }
            catch (SecurityTokenException)
            {
                context.Result = new RedirectResult("/Auth/Login");
                return;
            }
        }
    }
}

