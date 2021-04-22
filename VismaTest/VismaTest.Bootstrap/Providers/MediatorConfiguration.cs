using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Application.Mediators.UserOperations.Create;

namespace VismaTest.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateUserRequest).Assembly);

            return services;
        }
    }
}
