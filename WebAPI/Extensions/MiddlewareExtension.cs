using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Esame_Enterprise.Application.Factories;

namespace Esame_Enterprise.Web.Extensions
{
    public static class MiddlewareExtensions
    {

        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                        .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(res);
                    }
                });
            });
            app.MapControllers();
            return app;
        }

    }
}
