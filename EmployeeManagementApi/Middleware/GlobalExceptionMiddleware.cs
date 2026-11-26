using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next; //The next middleware in the pipeline.
        private readonly ILogger<GlobalExceptionMiddleware> _logger; //The logger instance for logging the exception details.

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;   
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); //Call the next middleware in the pipeline.
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "An unhandled Business Conflict has occurred."); //Log the exception details.
                await HandleExceptionAsync(context, StatusCodes.Status409Conflict, "Business Conflict", ex.Message); //Handle the exception and return a response to the client.
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred."); //Log the exception details.
                await HandleExceptionAsync(context, StatusCodes.Status500InternalServerError, "Internal Server Error", ex.Message); //Handle the exception and return a response to the client.
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, int statusCode, string title, string detail)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json"; //This is the standard content type for problem details responses.

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path
            };
            await context.Response.WriteAsJsonAsync(problemDetails); //Write the problem details to the response body as JSON.
        }
    }
}
