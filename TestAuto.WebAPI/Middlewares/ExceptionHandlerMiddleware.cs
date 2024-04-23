using FluentValidation;
using System.Net;
using TestAuto.Infrastructure.Exceptions;

namespace TestAuto.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next, 
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException ex)
            {
                _logger.LogWarning(ex.Message);
                await BadRequesExceptionHandler(context, ex);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                await BadRequesExceptionHandler(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                await BadWorkServerExceptionHandler(context, ex);
            }
        }

        private async Task BadWorkServerExceptionHandler(HttpContext context, Exception ex)
        {
            var response = new
            {
                code = HttpStatusCode.InternalServerError,
                message = "ошибка сервера, ппробуйте позже",
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.code;

            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task BadRequesExceptionHandler(HttpContext context, Exception ex)
        {
            var response = new
            {
                code = HttpStatusCode.BadRequest,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.code;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
