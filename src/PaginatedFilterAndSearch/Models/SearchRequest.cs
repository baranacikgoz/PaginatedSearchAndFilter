using PaginatedFilterAndSearch.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Models;

public class SearchRequest
{
    public SearchRequest(
        [DisallowNull, NotNull] int pageNumber,
        [DisallowNull, NotNull] int pageSize,
        ICollection<string>? orderby = null,
        string? keyword = null,
        AdvancedSearch? advancedSearch = null,
        AdvancedFilter? advancedFilter = null)
    {
        ValueNegativeException.ThrowIfNegative(pageNumber, nameof(pageNumber));
        ValueNegativeException.ThrowIfNegative(pageSize, nameof(pageSize));

        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderby;
        Keyword = keyword;
        AdvancedSearch = advancedSearch;
        AdvancedFilter = advancedFilter;
    }

    public int PageNumber { get; }

    public int PageSize { get; }

    public ICollection<string>? OrderBy { get; }
    public AdvancedSearch? AdvancedSearch { get; }

    /// <summary>
    /// Keyword to Search in All the available columns of the Resource.
    /// </summary>
    public string? Keyword { get; }

    /// <summary>
    /// Advanced column filtering with logical operators and query operators is supported.
    /// </summary>
    public AdvancedFilter? AdvancedFilter { get; }

    public bool HasOrderBy() => OrderBy?.Count > 0;
}