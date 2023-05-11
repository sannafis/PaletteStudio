using Newtonsoft.Json;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Static;
using System.Net;

namespace PaletteStudioApi.Utilities
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate request, ILogger<ExceptionHandler> logger)
        {
            this._request = request;
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong during {context.Request.Path}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Handle exception. respond with json
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            // Default error - Failure
            var errorDetails = new ErrorDetails
            {
                ErrorMessage = ex.Message,
                ErrorType = ErrorType.Failure
            };

            switch (ex) // Set the error type according to the exception
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = ErrorType.NotFound;
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorDetails.ErrorType = ErrorType.BadRequest;
                    break;
                case UnauthorizedException unauthorizedException:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorDetails.ErrorType = ErrorType.Unauthorized;
                    break;
                default:
                    break;
            }

            // serialize json response
            string response = JsonConvert.SerializeObject(errorDetails);

            context.Response.StatusCode = (int)statusCode; // set status code
            return context.Response.WriteAsync(response);   
        }

    }
}