using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISeriLog seriLog;
        private string error = "";

        public LogMiddleware(RequestDelegate next, ISeriLog seriLog)
        {
            _next = next;
            this.seriLog = seriLog;
        }

        public Task Invoke(HttpContext httpContext)
        {
           return _next.Invoke(httpContext);
           // return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {  
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
