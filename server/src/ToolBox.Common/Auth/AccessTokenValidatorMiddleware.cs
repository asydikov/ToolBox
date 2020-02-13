using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ToolBox.Common.Auth
{
    public class AccessTokenValidatorMiddleware : IMiddleware
    {
        public AccessTokenValidatorMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}