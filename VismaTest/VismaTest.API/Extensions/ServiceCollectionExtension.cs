using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using VismaTest.API.Presenters;
using VismaTest.API.Presenters.Interfaces;

namespace VismaTest.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection ConfigureCustomServices(this IServiceCollection service)
        {
            service.AddTransient<IUserPresenter, UserPresenter>();
            service.AddTransient<IRolePresenter, RolePresenter>();
            return service;
        }

    }
}
