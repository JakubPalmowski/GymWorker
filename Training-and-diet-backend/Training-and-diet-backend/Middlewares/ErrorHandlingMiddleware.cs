using Training_and_diet_backend.Exceptions;

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

            
        }
    }
}
