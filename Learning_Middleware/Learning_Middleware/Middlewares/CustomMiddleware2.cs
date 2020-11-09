using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Middleware.Middlewares
{
    public class CustomMiddleware2
    {
        private string Str;
        private RequestDelegate Next;
        public CustomMiddleware2(RequestDelegate next, string str)
        {
            Str = str;
            Next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("CustomMiddleware2-START");
            Console.WriteLine(Str);
            await Next(context);
            Console.WriteLine("CustomMiddleware2-STOP");
        }

    }
}
