using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shared.Infrastructure.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAppLogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, IAppLogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoce(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

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
}
