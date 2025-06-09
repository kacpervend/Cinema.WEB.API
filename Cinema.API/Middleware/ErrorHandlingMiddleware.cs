using Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Cinema.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (UnauthorizedException unauthorizedException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(unauthorizedException.Message);
            }
            catch (Application.Exceptions.InvalidOperationException invalidOperationException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(invalidOperationException.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong...");
            }
        }
    }
}
