using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esame_Enterprise.Application.Extensions
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(
                AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Esame_Enterprise.Application"));
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }

    }
}
