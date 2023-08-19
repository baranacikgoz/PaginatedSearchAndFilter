using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Abstractions;

public interface ICache
{
    Task<T> GetAsync<T>(string key);

    Task SetAsync<T>(string key, T value);
}