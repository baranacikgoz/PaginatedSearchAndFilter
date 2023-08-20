using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Abstractions;

public interface IClassFieldsCache
{
    Task InitializeAsync([NotNull] ICollection<Type> types);

    Task<Type> GetFieldTypeAsync<T>([NotNull] string fieldName);

    Task EnsureFieldExistsAsync<T>([NotNull] string fieldName);
}