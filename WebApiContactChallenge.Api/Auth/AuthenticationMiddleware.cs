using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApiContactChallenge.Api.Auth
{
    public class AuthenticationMiddleware
    {
        public const string FakeAuthorization = "FakeAuthorization";

        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            // TODO : Manage middleware
            // if (context.Request.Path.StartsWithSegments("/index.html") || context.Request.Path.StartsWithSegments("/swagger"))
            // {
            //     await _next.Invoke(context);
            // }
            // else
            // {
            //     string authHeader = context.Request.Headers["FakePassword"];
            //     if (authHeader != null)
            //     {
            //         if (authHeader == "1234") // TODO just for demo, password set by defaut to 1234
            //         {
            //             await _next.Invoke(context);
            //         }
            //
            //         context.Response.StatusCode = 401; //Unauthorized
            //         await context.Response.WriteAsync("Unauthorized");
            //
            //     }
            //
            //     context.Response.StatusCode = 401; //Unauthorized
            //     await context.Response.WriteAsync("Unauthorized");
            //     return;
            // }
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}