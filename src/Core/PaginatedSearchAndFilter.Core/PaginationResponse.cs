using PaginatedSearchAndFilter.Models.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class PaginationResponse<T>
{
    public PaginationResponse(
        [NotNull] IEnumerable<T> data,
        [NotNull] int totalCount,
        [NotNull] int pageNumber,
        [NotNull] int pageSize)
    {
        ValueNegativeException.ThrowIfNegative(totalCount, nameof(totalCount));
        ValueNegativeException.ThrowIfNegative(pageNumber, nameof(pageNumber));
        ValueNegativeException.ThrowIfNegative(pageSize, nameof(pageSize));

        var totalNumberOfPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        PageNumberExceedsTotalNumberOfPagesException.ThrowIfNecessary(pageNumber, totalNumberOfPages);

        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalNumberOfPages = totalNumberOfPages;
        TotalCount = totalCount;
    }

    public IEnumerable<T> Data { get; }

    public int PageNumber { get; }

    public int TotalNumberOfPages { get; }

    public int TotalCount { get; }

    public int PageSize { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalNumberOfPages;
}