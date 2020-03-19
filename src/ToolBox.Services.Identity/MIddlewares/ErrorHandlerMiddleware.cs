using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToolBox.Common.Exceptions;

namespace ToolBox.Services.Identity.MIddlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(context, ex);
            }
        }

        private static Task HandleErrorAsync(HttpContext context, Exception ex)
        {
            var exceptionType = ex.GetType();
            var statusCode = HttpStatusCode.InternalServerError;
            var errorCode = "error";

            switch (ex)
            {
                case ToolBoxException e when exceptionType == typeof(ToolBoxException):
                    errorCode = e.Code;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ToolBoxException e when exceptionType == typeof(UnauthorizedAccessException):
                    errorCode = "unauthorized";
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case ToolBoxException e when exceptionType == typeof(ArgumentException):
                    errorCode = "invalid_parameter";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            var response = new { message = ex.Message, errorCode = errorCode };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(payload);
        }
    }
}
