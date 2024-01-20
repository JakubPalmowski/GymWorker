using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;

namespace Training_and_diet_backend.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {


        public ErrorHandlingMiddleware()
        {

        }

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
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (ConflictException conflictException)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(conflictException.Message);
            }
            catch (UnauthorizedException unauthorizedException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(unauthorizedException.Message);

            }
            catch (ForbiddenException forbiddenException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbiddenException.Message);
            }
           
        }
    }
}
