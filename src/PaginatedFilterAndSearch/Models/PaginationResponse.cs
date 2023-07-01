using PaginatedFilterAndSearch.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedFilterAndSearch.Models;

public class PaginationResponse<T>
{
    public PaginationResponse(
        [DisallowNull, NotNull] IEnumerable<T> data,
        [DisallowNull, NotNull] int count,
        [DisallowNull, NotNull] int pageNumber,
        [DisallowNull, NotNull] int pageSize)
    {
        ValueNegativeException.ThrowIfNegative(count, nameof(count));
        ValueNegativeException.ThrowIfNegative(pageNumber, nameof(pageNumber));
        ValueNegativeException.ThrowIfNegative(pageSize, nameof(pageSize));

        var totalNumberOfPages = (int)Math.Ceiling(count / (double)pageSize);

        if (pageNumber > totalNumberOfPages)
        {
            throw new PageNumberExceedsTotalNumberOfPagesException(pageNumber, totalNumberOfPages);
        }
        if (pageSize > count)
        {
            throw new PageSizeExceedsTotalNumberOfDataException(pageSize, count);
        }

        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalNumberOfPages = totalNumberOfPages;
        TotalCount = count;
    }

    public IEnumerable<T> Data { get; }

    public int PageNumber { get; }

    public int TotalNumberOfPages { get; }

    public int TotalCount { get; }

    public int PageSize { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalNumberOfPages;
}