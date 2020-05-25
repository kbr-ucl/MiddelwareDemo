using Microsoft.AspNetCore.Builder;

namespace IpFilterMiddelware.Mvc.Middelware
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseIpFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpFilterMiddleware>();
        }
    }
}