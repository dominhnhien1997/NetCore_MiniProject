using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHandleingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandleingMiddleware> _logger;
        public ErrorHandleingMiddleware(RequestDelegate next, ILogger<ErrorHandleingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandleingMiddleware> logger)
        {
            object errors = null;
            switch (ex)
            {
                case RestException re:
                    _logger.LogError(ex, "REST ERROR");
                    errors = re.errors;
                    break;
                default:
                    break;
            }
        }
    }
}
