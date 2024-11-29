using Microsoft.AspNetCore.Mvc;
using Cafe.Application.Common.Exceptions;
using Event.Application.Common.Exceptions;

namespace Cafe.Presentation.Common.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _ = context.User;
        try
        {
            await _requestDelegate(context);
        }
        catch (InvalidOperationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Invalid operation",
                Detail = exception.Message
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NotFoundException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found",
                Detail = exception.Message
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (InvalidTokenException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Invalid token",
                Detail = exception.Message
            };

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (AlreadyExistsException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "The specified resource already exists",
                Detail = exception.Message
            };

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "Error occured on server"
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problemDetails);

            throw;
        }
    }
}
