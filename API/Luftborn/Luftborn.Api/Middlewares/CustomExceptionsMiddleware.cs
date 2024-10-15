using Luftborn.Core.Entities.Shared;
using Luftborn.Core.Exceptions;
using Luftborn.Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace Luftborn.Api.Middlewares
{
    public class CustomExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public CustomExceptionsMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                context.Response.ContentType = "application/json";

                switch (error)
                {
                    case ValidationCustomException validationEx:
                        await HandleExceptionAsync(context, validationEx.Message, HttpStatusCode.Forbidden);
                        break;
                    case DatabaseException dbEx:
                        await HandleExceptionAsync(context, dbEx.Message, HttpStatusCode.InternalServerError);
                        break;
                    case NotFoundException notFoundEx:
                        await HandleExceptionAsync(context, notFoundEx.Message, HttpStatusCode.NotFound);
                        break;
                    default:
                        await HandleExceptionAsync(context, "An unhandled exception occurred.", HttpStatusCode.InternalServerError);
                        break;
                }
            }

        }
        private Task HandleExceptionAsync(HttpContext context, string errorMessage, HttpStatusCode statusCode)
        {
            context.Response.StatusCode = (int)statusCode;

            ApiResponse<object> response = ApiResponseHelper.Failure<object>(context.Request, errorMessage);
            string jsonResponse = JsonConvert.SerializeObject(response);

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
