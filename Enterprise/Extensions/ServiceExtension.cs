﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Context;
using Model.Repositories;

namespace Model.Extensions
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<BookRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<BookCategoryRepository>();
            services.AddScoped<UserRepository>();
            return services;
        }

    }
}
