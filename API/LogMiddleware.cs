namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISeriLog seriLog;
        public LogMiddleware(RequestDelegate next, ISeriLog seriLog)
        {
            _next = next;
            this.seriLog = seriLog;
            this.seriLog.Log("A");
        }

        public Task Invoke(HttpContext httpContext)
        {
           return _next.Invoke(httpContext);
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
