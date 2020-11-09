using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Learning_Middleware.Middlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Learning_Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<CustomMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("1-START");
                await next();
                Console.WriteLine("1-STOP");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("2-START");
                await next();
                Console.WriteLine("2-STOP");
            });

            app.UseMiddleware<CustomMiddleware>();
            app.UseMiddleware<CustomMiddleware2>("TEST ARGS");
        }
    }
}
