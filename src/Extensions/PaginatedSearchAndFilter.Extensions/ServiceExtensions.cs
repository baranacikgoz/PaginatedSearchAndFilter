using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Core.Implementations;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Extensions;

public static class ServiceExtensions
{
    public static void AddPaginatedSearchAndFilter(
        [NotNull] this IServiceCollection services,
        [NotNull] Action<PaginatedSearchAndFilterOptions> configureOptions)
    {
        var options = new PaginatedSearchAndFilterOptions();
        configureOptions(options);

        if (options.Cache is null)
        {
            services.AddSingleton<ICache, DefaultCache>();
        }

        options.ConfigureServicesAction?.Invoke(services);
    }

    public static IApplicationBuilder InitializePaginatedSearchAndFilterCache(
        [NotNull] this IApplicationBuilder app,
        [NotNull] ICollection<Type> types)
    {
        IClassFieldsCache propertyTypesCache = app.ApplicationServices.GetRequiredService<IClassFieldsCache>();

        propertyTypesCache.InitializeAsync(types).GetAwaiter().GetResult();

        return app;
    }
}