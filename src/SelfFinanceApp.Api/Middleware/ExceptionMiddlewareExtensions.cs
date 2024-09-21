using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SelfFinanceApp.Api.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>();

                    switch (exception!.Error)
                    {
                        case ValidationException validationException:

                            var problemDetails = new ProblemDetails
                            {
                                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                                Status = StatusCodes.Status400BadRequest,
                                Title = "Validation error",
                                Detail = string.Join(" ", validationException.Errors
                                    .Select(e => e.ErrorMessage))
                            };

                            await context.Response.WriteAsJsonAsync(problemDetails);
                            break;

                        case KeyNotFoundException _:
                            await context.Response.WriteAsJsonAsync(new ProblemDetails
                            {
                                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                                Status = StatusCodes.Status404NotFound,
                                Title = "Not found",
                                Detail = exception.Error.Message
                            });
                            break;

                        default:
                            await context.Response.WriteAsJsonAsync(new ProblemDetails
                            {
                                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                                Status = StatusCodes.Status500InternalServerError,
                                Title = "Internal server error",
                                Detail = exception.Error.Message
                            });
                            break;
                    }
                });
            });
        }
    }
}
