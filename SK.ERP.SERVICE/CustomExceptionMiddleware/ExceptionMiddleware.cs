using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SK.ER.Utilities.Keys;
using SK.ERP.Entities.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio un error Servicio Seguridad: {ex}");
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var _genericResponse = new GenericResponseObject
            {
                Code = Enums.eCode.ERROR,
                Data = new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error"
                }
            }.ToString();

            return context.Response.WriteAsync(_genericResponse);
        }
    }
}
