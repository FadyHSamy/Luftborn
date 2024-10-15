﻿using Luftborn.Core.Entities.Shared;
using Luftborn.Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace Luftborn.Api.Middlewares
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;
                try
                {
                    await _next(context);

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    context.Response.ContentType = "application/json";
                    string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
                    context.Response.Body = originalBodyStream;
                    string result;

                    if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
                    {
                        result = await HandleSuccessResponseAsync(responseBody, context);
                    }
                    else
                    {
                        result = await HandleFailureResponseAsync(responseBody, context);

                    }
                    await context.Response.WriteAsync(result);
                }
                catch (Exception ex)
                {
                    await HandleExceptionResponseAsync(await new StreamReader(memoryStream).ReadToEndAsync(), context, ex);
                }
                finally
                {
                    // Copy the contents of the new memory stream (responseBody) to the original stream
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }

        }

        private async Task<string> HandleSuccessResponseAsync(string responseBody, HttpContext context)
        {
            try
            {
                var existingApiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody);
                if (existingApiResponse != null && existingApiResponse.IsSuccess)
                {
                    return responseBody;
                }
            }
            catch (JsonException)
            {
            }

            ApiResponse<object> apiResponse = new ApiResponse<object>
            {
                IsSuccess = true,
                Message = "Request completed successfully.",
                Data = Helpers.IsEmptyString(responseBody) ? null : JsonConvert.DeserializeObject<object>(responseBody),
                RequestApiUrl = context.Request.GetDisplayUrl()
            };

            return JsonConvert.SerializeObject(apiResponse);

        }

        private async Task<string> HandleFailureResponseAsync(string responseBody, HttpContext context)
        {
            try
            {
                ApiResponse<object> existingApiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody)!;
                if (existingApiResponse != null && !existingApiResponse.IsSuccess)
                {
                    return responseBody;
                }
            }
            catch (JsonException)
            {
            }

            ApiResponse<object> apiResponse = new ApiResponse<object>
            {
                IsSuccess = false,
                Message = "An error occurred.",
                Data = null,
                RequestApiUrl = context.Request.GetDisplayUrl()
            };
            return JsonConvert.SerializeObject(apiResponse);

        }

        private async Task HandleExceptionResponseAsync(string responseBody, HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;
            ApiResponse<object> apiResponse = new ApiResponse<object>
            {
                IsSuccess = false,
                Message = "An internal server error occurred.",
                Data = null,
                RequestApiUrl = context.Request.GetDisplayUrl()
            };

            string result = JsonConvert.SerializeObject(apiResponse);
            await context.Response.WriteAsync(result);
        }

    }
}
