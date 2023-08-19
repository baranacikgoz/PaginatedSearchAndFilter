using PaginatedSearchAndFilter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Abstractions;

public interface ISqlBuilder
{
    (string sql, ICollection<QueryParameter> parameters) Build(
        string baseQuery,
        string baseTableName,
        string? baseTableAlias,
        int pageNumber,
        int pageSize,
        ICollection<AdvancedSearch>? advancedSearches = null,
        CombinedAdvancedFilters? combinedAdvancedFilters = null);
}