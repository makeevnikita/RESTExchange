using System.Text.Json;
using src.Exceptions;


namespace src.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly JsonSerializerOptions serializerOptions;
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
        serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {   
            switch (exception)
            {
                case ObjectNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            string result = JsonSerializer.Serialize(
                new { message = exception.Message,
                      status = context.Response.StatusCode
                    }
                );
            await context.Response.WriteAsync(result);
        }
    }
}