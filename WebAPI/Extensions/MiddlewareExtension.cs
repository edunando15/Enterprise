using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Esame_Enterprise.Application.Factories;

namespace Esame_Enterprise.Web.Extensions
{
    public static class MiddlewareExtensions
    {

        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            app.UseSwagger(); // genera un documento JSON con tutti gli endpoint
            app.UseSwaggerUI(); // usa il documento generato per creare un'interfaccia grafica usabile
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            // middleware per gestire le eccezioni non gestite: mette errore 500 e restituisce un oggetto JSON con l'errore
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
            // mappa le rotte sui controller (raggiungibili da url)
            app.MapControllers();
            return app;
        }

    }
}
