using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                var _genericResponse = new GenericResponseObject
                {
                    Code = Enums.eCode.NOAUTH,
                    Message = "Access to the Web API is not authorized"
                }.ToString();

                context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                await context.HttpContext.Response.WriteAsync(_genericResponse);
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>(key: "ApiKey");

            if (!apiKey.Equals(potentialApiKey))
            {
                var _genericResponse = new GenericResponseObject
                {
                    Code = Enums.eCode.NOAUTH,
                    Message = "Access to the Web API is not authorized"
                }.ToString();

                context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                await context.HttpContext.Response.WriteAsync(_genericResponse);
                return;
            }
            await next();
        }
    }
}
