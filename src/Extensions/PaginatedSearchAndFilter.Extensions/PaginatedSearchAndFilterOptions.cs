using Microsoft.Extensions.DependencyInjection;
using PaginatedSearchAndFilter.Core.Abstractions;
using System;

namespace PaginatedSearchAndFilter.Extensions;

public class PaginatedSearchAndFilterOptions
{
    internal ICache? Cache { get; set; }

    // Use Action<IServiceCollection> to define the delegate
    internal Action<IServiceCollection> ConfigureServicesAction { get; set; }

    public PaginatedSearchAndFilterOptions UseCache(ICache? cache)
    {
        Cache = cache;
        return this;
    }

    public PaginatedSearchAndFilterOptions ConfigureServices(Action<IServiceCollection> configureServices)
    {
        ConfigureServicesAction = configureServices;
        return this;
    }
}