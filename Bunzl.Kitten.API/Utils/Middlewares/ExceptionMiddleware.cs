using System;
using System.Net;
using System.Threading.Tasks;
using Bunzl.Kitten.API.DTOs;
using Microsoft.AspNetCore.Http;

namespace Bunzl.Kitten.API.Utils.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorResponse()
            {
                Message = exception.Message
            }.ToString());
        }
    }
}
