using Esame_Enterprise.Application.Options;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Esame_Enterprise.Web.Results;

namespace Esame_Enterprise.Web.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestResultFactory(context);
                    };
                });
            services.AddEndpointsApiExplorer();
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Enterprise",
                    Version = "v1"
                });
                // definizione della sicurezza
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
                });
                // Per tutte le api.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }

        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtAuthOpt = new JwtAuthenticationOption();
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthOpt);
            // aggiungiamo l'autenticazione, e impostiamo lo schema di autenticazione predefinito a JwtBearer....AuthenticationScheme
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                // aggiungiamo il JwtBearer per validare i token JWT delle varie richieste
                .AddJwtBearer(options =>
            {
                string key = jwtAuthOpt.Key;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                // parametri per la convalida del token
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true, // chi emette il token deve essere verificato
                    ValidateLifetime = true, // il tempo di vita del token deve essere verificato
                    ValidateAudience = false, // chi utilizza il token non deve essere verificato
                    ValidateIssuerSigningKey = true, // la chiave di firma del token deve essere verificata
                    ValidIssuer = jwtAuthOpt.Issuer, // chi emette il token. Viene controllato che chi lo emette sia questo.
                    IssuerSigningKey = securityKey // chiave di firma
                };
            });
            services.Configure<JwtAuthenticationOption>(configuration.GetSection("JwtAuthentication"));
            return services;
        }
    }
}
