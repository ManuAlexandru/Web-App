using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Licenta.BLL.Utils.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity is not null
                && context.User.Identity.IsAuthenticated)
            {
                string currentRole = context.User.Claims?.FirstOrDefault(x => x.Type == "Role").Value;

                context.User.AddIdentity(new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultRoleClaimType,currentRole)
            }));

            }
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
