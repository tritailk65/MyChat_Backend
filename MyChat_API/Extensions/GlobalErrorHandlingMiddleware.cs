﻿using System.Text.Json;
using MyChat_API.Exceptions;

namespace MyChat_API.Extensions
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            logger.LogError(exception.ToString());
            int status = 0;
            int? statusCustom = 0;
            var data = string.Empty;
            string message = "";
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = ((BadRequestException)exception).StatusCode;
                statusCustom = ((BadRequestException)exception).StatusCodeCustom;
            }

            var exceptionResult = JsonSerializer.Serialize(new
            {
                status = statusCustom,
                message,
                data
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status;
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
