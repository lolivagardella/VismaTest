using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace VismaTest.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class MvcConfiguration
    {
        public static IServiceCollection ConfigureMVCServices(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddApiVersion();
            services.AddControllers(options =>
            {
                options.AddTraceIncomingRequestFilter();
            });

            return services;
        }

        public static IApplicationBuilder ConfigureMVC(this IApplicationBuilder app,
            IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            return app;
        }
    }
}