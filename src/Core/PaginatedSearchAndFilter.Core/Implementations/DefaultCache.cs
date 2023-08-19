using PaginatedSearchAndFilter.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Implementations;

public class DefaultCache : ICache
{
    private readonly Dictionary<string, object> _cache = new();

    public Task<T> GetAsync<T>(string key)
    {
        if (_cache.TryGetValue(key, out var value) && value is T typedValue)
        {
            return Task.FromResult(typedValue);
        }

        return Task.FromResult(default(T));
    }

    public Task SetAsync<T>(string key, T value)
    {
        _cache[key] = value;

        return Task.CompletedTask;
    }
}