
using Luftborn.Api.Middlewares;

namespace Luftborn.Api.Extensions
{
    public static class MiddlewareCollectionExtensions
    {
        public static void AddCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiResponseMiddleware>();
            app.UseMiddleware<CustomExceptionsMiddleware>();
        }
    }
}
