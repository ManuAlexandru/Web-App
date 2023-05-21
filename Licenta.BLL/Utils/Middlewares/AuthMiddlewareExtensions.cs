using Microsoft.AspNetCore.Builder;

namespace Licenta.BLL.Utils.Middlewares
{
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
