using System.Net;
using System.Text.Json;

namespace TodoApp.Web.Common;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            _logger.LogError(ex, "An unhandled exception has occured.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var errorResponse = new
        {
            message = exception.Message,
            details = exception.InnerException?.Message
        };

        response.StatusCode = exception switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound, // 404
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
            _ => (int)HttpStatusCode.InternalServerError // default: 500
        };

        var result = JsonSerializer.Serialize(errorResponse);
        return response.WriteAsync(result);
    }
}
