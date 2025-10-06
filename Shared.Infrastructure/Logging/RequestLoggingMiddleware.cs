using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var _logger = context.RequestServices.GetRequiredService<IAppLogger<RequestLoggingMiddleware>>();

            _logger.LogInfo($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInfo($"Request {context.Request.Method} {context.Request.Path} completed in {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
