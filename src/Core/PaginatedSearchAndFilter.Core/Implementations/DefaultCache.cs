using PaginatedSearchAndFilter.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Implementations;

/// <summary>
/// The default cache implementation when users don't register an ICache implementation to the service provider..
/// </summary>
public class DefaultCache : ICache
{
    private readonly Dictionary<string, object> _cache = new();

    public Task<T> GetAsync<T>(string key) => Task.FromResult((T)_cache[key]);

    public Task SetAsync<T>(string key, T value)
    {
        _cache[key] = value!;
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(string key) => Task.FromResult(_cache.ContainsKey(key));
}