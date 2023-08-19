using PaginatedSearchAndFilter.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Implementations;

public class ClassPropertyTypesCache : IClassPropertyTypesCache
{
    private readonly ICache _cache;

    public ClassPropertyTypesCache(ICache cache) => _cache = cache;

    public async Task InitializeAsync(ICollection<Type> types)
    {
        foreach (Type type in types)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var cacheKey = CacheKey(type, property.Name);
                await _cache.SetAsync(cacheKey, property.PropertyType.AssemblyQualifiedName);
            }
        }
    }

    public async Task<Type> GetPropertyTypeAsync<T>(string propertyName)
    {
        string cacheKey = CacheKey(typeof(T), propertyName);
        var assemblyQualifiedName = await _cache.GetAsync<string>(cacheKey);
        return Type.GetType(assemblyQualifiedName);
    }

    private static string CacheKey(Type type, string property) => $"{type.FullName}-{property}";
}