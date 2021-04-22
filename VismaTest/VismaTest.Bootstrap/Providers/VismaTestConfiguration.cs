using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Domain.Repositories;
using VismaTest.Persistance.Commands;

namespace VismaTest.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class VismaTestConfiguration
    {
        public static IServiceCollection ConfigureVismaTestServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRolRepository, RoleRepository>();
            return services;
        }
    }
}