using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Core.Implementations;

namespace PaginatedSearchAndFilter.Extensions;

public static class ServiceExtensions
{
    public static void AddPaginatedSearchAndFilter(this IServiceCollection services, Action<PaginatedSearchAndFilterOptions> configureOptions)
    {
        var options = new PaginatedSearchAndFilterOptions();
        configureOptions(options);

        if (options.Cache is null)
        {
            services.AddSingleton<ICache, DefaultCache>();
        }

        options.ConfigureServicesAction?.Invoke(services);
    }

    public static IApplicationBuilder InitializePaginatedSearchAndFilterCache(this IApplicationBuilder app, ICollection<Type> types)
    {
        IClassPropertyTypesCache propertyTypesCache = app.ApplicationServices.GetRequiredService<IClassPropertyTypesCache>();

        propertyTypesCache.InitializeAsync(types).GetAwaiter().GetResult();

        return app;
    }
}