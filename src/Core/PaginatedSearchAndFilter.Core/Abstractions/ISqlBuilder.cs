using PaginatedSearchAndFilter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Abstractions;

public interface ISqlBuilder
{
    Task<(string sql, ICollection<QueryParameter> parameters)> Build<T>(
        [NotNull] string baseQuery,
        [NotNull] string baseTableName,
                  string? baseTableAlias,
        [NotNull] int pageNumber,
        [NotNull] int pageSize,
                  ICollection<AdvancedSearch>? advancedSearches = null,
                  CombinedAdvancedFilters? combinedAdvancedFilters = null);
}