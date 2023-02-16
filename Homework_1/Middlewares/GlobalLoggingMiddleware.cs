using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Homework_1.Middlewares
{
    public class GlobalLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string message = "Logging is successfull.";
            System.Console.WriteLine(message);
            await _next(httpContext);
        }
    }
}
