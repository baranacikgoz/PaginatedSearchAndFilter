using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Implementations;

public class ClassFieldsCache : IClassFieldsCache
{
    private readonly ICache _cache;

    public ClassFieldsCache(ICache cache) => _cache = cache;

    public async Task InitializeAsync([NotNull] ICollection<Type> types)
    {
        foreach (Type type in types)
        {
            var fields = type.GetProperties();
            foreach (var field in fields)
            {
                var cacheKey = CacheKey(type, field.Name);
                await _cache.SetAsync(cacheKey, field.PropertyType.AssemblyQualifiedName).ConfigureAwait(false);
            }
        }
    }

    public async Task<Type> GetFieldTypeAsync<T>([NotNull] string fieldName)
    {
        string cacheKey = CacheKey(typeof(T), fieldName);
        var assemblyQualifiedName = await _cache.GetAsync<string>(cacheKey).ConfigureAwait(false);
        return Type.GetType(assemblyQualifiedName);
    }

    public async Task EnsureFieldExistsAsync<T>([NotNull] string fieldName)
    {
        Type type = typeof(T);

        string key = CacheKey(type, fieldName);
        bool exists = await _cache.ExistsAsync(key).ConfigureAwait(false);

        if (!exists)
        {
            throw new FieldNotExistException(type, fieldName);
        }
    }

    private static string CacheKey(Type type, string property) => $"{type.FullName}-{property}";
}