using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleMiddelware.Web
{
    public class StartupInline
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            // Middleware A
            app.Use(async (context, next) =>
            {
                Console.WriteLine("A (in)");
                await next().ConfigureAwait(false);
                Console.WriteLine("A (out)");
            });

            // Middleware B
            app.Use(async (context, next) =>
            {
                Console.WriteLine("B (in)");
                await next().ConfigureAwait(false);
                Console.WriteLine("B (out)");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => context.Response.WriteAsync("Hello World!"));
            });
        }
    }
}