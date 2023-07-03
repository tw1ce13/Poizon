using Microsoft.EntityFrameworkCore;
using Poizon.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Poizon.Domain.Response;
using Serilog;
using Newtonsoft.Json;


namespace Poizon.Services.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            await HandleUpdateErrorAsync(context, ex);
        }
    }

    private async Task HandleUpdateErrorAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)StatusCode.Error;
        var errorResponse = new ErrorResponse();
        switch (ex)
        {
            case DbUpdateException:
                errorResponse = new ErrorResponse()
                {
                    StatusCode = StatusCode.Error,
                    Message = ex.Message,
                    Description = "Update Error"
                };
                break;
            case NullReferenceException:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Message = ex.Message,
                    Description = "There is no such object"
                };
                break;
            case InvalidOperationException:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Message = ex.Message,
                    Description = "Invalid operation"
                };
                break;
            default:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Message = ex.Message,
                    Description = "Error"
                };
                break;
        }
        var jsonError = JsonConvert.SerializeObject(errorResponse);
        await context.Response.WriteAsync(jsonError);
    }
}

