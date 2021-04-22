using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Bootstrap.Providers;

namespace VismaTest.Bootstrap
{
    [ExcludeFromCodeCoverage]
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.ConfigureMVCServices();
            services.ConfigureSwaggerServices(configuration);
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureVismaTestServices(configuration);
            services.ConfigureMediatrServices();

            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app,
            IWebHostEnvironment webHostEnvironment,
            IApiVersionDescriptionProvider provider,
            IConfiguration configuration,
            IHostApplicationLifetime appLifetime)
        {
            app.UsePathBase(configuration["BasePath"]);
            app.ConfigureMVC(webHostEnvironment);
            app.ConfigureSwagger();
            app.RunMigrations();

            return app;
        }
    }
}
