﻿using Azure.Identity;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository;

namespace ProjectEmployeeServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureCosmosDB(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {
            IHostEnvironment environment2 = environment;
            string dataBaseId = configuration["ConnectionStrings:CosmosDb:DatabaseId"];
            string accountEndPoint = configuration["ConnectionStrings:CosmosDb:Accountkey"];
            services.AddDbContext<RepositoryContext>(delegate (DbContextOptionsBuilder options)
            {
                if (accountEndPoint.Contains("AccountKey", StringComparison.OrdinalIgnoreCase))
                {
                    options.UseCosmos(accountEndPoint, dataBaseId);
                }
                else
                {
                    options.UseCosmos(accountEndPoint, new DefaultAzureCredential(), dataBaseId);
                }

                if (environment2.IsDevelopment())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }

                options.ConfigureWarnings(delegate (WarningsConfigurationBuilder w)
                {
                    w.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning);
                });
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
