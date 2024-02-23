using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                          Exception exception,
                                          CancellationToken cancellationToken)
    {
        var response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = exception switch
        {
            ArgumentNullException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var pd = new ProblemDetails
        {
            Title = exception.Message,
            Status = response.StatusCode,
            Detail = exception.StackTrace
        };

        var result = JsonSerializer.Serialize(pd);
        await response.WriteAsync(result, cancellationToken);
        return true;
    }
}