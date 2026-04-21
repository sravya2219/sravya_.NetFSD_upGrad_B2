using System.Net;
using System.Text.Json;
using API.Models;
using API.Exceptions;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";

                var response = context.Response;

                var error = new ErrorResponse
                {
                    Message = "Something went wrong",
                    Timestamp = DateTime.UtcNow
                };

                switch (ex)
                {
                    case NotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        error.Message = ex.Message;
                        break;

                    case ArgumentException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error.Message = ex.Message;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                error.StatusCode = response.StatusCode;

                var result = JsonSerializer.Serialize(error);
                await context.Response.WriteAsync(result);
            }
        }
    }
}