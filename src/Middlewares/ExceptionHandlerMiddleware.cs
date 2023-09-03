using System.Text.Json;
using src.Exceptions;


namespace src.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
        catch (Exception exception)
        {   
            _logger.LogError($"Message: {exception.Message}\nStackTrace: {exception.StackTrace}");

            string exMessage = exception.Message;
            switch (exception)
            {
                case ObjectNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    exMessage = "Internal Server Error";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            string result = JsonSerializer.Serialize(
                new { message = exMessage,
                      status = context.Response.StatusCode
                    }
                );
            await context.Response.WriteAsync(result);
        }
    }
}