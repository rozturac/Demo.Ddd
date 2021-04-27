using Lolaflora.Baskets.Application.Common;
using Lolaflora.Baskets.Application.Common.Exceptions;
using Lolaflora.Baskets.Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Infrastructure.Common.Exntesions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex, string.Concat(ex.Errors.Select(x => $"{x.Key}: {string.Join(",", x.Value)}")));
            }
            catch (BusinessRuleValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, "General system error");
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex, string message)
        {
            _logger.LogError(ex, ex.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(GenericResult<string>.Failure(message), Formatting.Indented));
        }
    }
}
