using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace VismaTest.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class VersionConfiguration
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddScoped<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
    }
}
