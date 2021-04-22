using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Domain.Repositories;
using VismaTest.Persistance;

namespace VismaTest.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {

            var connectionString = configuration.GetConnectionString("database");

            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContext<VismaTestDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UsersDbContextUnitOfWork>();

            if (addHealthCheck)
            {
                services.AddHealthChecks()
                    .AddSqlServer(connectionString, "SELECT 1;", tags: new string[] { "db", "sqlserver" });
            }

            return services;
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<VismaTestDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            return app;
        }
    }
}
