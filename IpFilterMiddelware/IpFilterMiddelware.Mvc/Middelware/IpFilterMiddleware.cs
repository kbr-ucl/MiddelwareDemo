using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IpFilterMiddelware.Mvc.Middelware
{
    public class IpFilterMiddleware
    {
        private readonly RequestDelegate _next;

        public IpFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Host.Host.Equals("localhost"))
            {
                await httpContext.Response.WriteAsync("Illegal IP!").ConfigureAwait(false);
                return;
            }

            await _next.Invoke(httpContext).ConfigureAwait(false);
        }
    }
}