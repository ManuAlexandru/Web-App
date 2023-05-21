using Licenta.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Licenta.BLL.Utils
{
    public static class IdentityUser
    {
        public static async Task CreateClaims(User user, HttpContext httpContext)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("username", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(claimsPrincipal);
        }
    }
}
