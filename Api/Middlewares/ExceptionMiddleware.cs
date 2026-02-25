using System.Net;

namespace Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            Log.Warning("Validation failed: {Errors}",
                ex.Errors.Select(e => e.ErrorMessage));

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.Fail(
                "400",
                "Validation failed",
                ex.Errors.Select(e => e.ErrorMessage));
            
            response.TraceId = context.TraceIdentifier;

            await context.Response.WriteAsJsonAsync(response);
        }

        catch (ConflictException ex)
        {
            Log.Warning("Conflict: {Message}", ex.Message);

            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.Fail(
                "409",
                ex.Message);

            response.TraceId = context.TraceIdentifier;

            await context.Response.WriteAsJsonAsync(response);
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

        var response = ApiResponse<object>.Fail(
                "500",
                "An unexpected error occurred");

            response.TraceId = context.TraceIdentifier;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}