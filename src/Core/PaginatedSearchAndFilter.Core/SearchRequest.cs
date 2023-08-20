using PaginatedSearchAndFilter.Models.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class SearchRequest
{
    public SearchRequest(
        [NotNull] int pageNumber,
        [NotNull] int pageSize,
        ICollection<OrderBy>? orderBys = null,
        ICollection<AdvancedSearch>? advancedSearches = null,
        CombinedAdvancedFilters? combinedAdvancedFilters = null)
    {
        ValueNegativeException.ThrowIfNegative(pageNumber, nameof(pageNumber));
        ValueNegativeException.ThrowIfNegative(pageSize, nameof(pageSize));

        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBys = orderBys;
        AdvancedSearches = advancedSearches;
        CombinedAdvancedFilters = combinedAdvancedFilters;
    }

    public int PageNumber { get; }
    public int PageSize { get; }
    public ICollection<OrderBy>? OrderBys { get; }
    public ICollection<AdvancedSearch>? AdvancedSearches { get; }
    public CombinedAdvancedFilters? CombinedAdvancedFilters { get; }

    public bool HasOrderBy() => OrderBys?.Count > 0;
}