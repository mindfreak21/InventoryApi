using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InventoryApi.Exceptions
{
    public static class ExceptionFactory
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, int StatusCode = 0, string message = "")
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        LogTraceFactory.LogError($"Something went wrong: {contextFeature.Error}");

                         await context.Response.WriteAsync(new Models.ErrorDetails()
                        {
                            statusCode = context.Response.StatusCode,
                            message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }

    }
}
