using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Abstractions;

public interface IClassPropertyTypesCache
{
    Task InitializeAsync(ICollection<Type> types);

    Task<Type> GetPropertyTypeAsync<T>(string propertyName);
}