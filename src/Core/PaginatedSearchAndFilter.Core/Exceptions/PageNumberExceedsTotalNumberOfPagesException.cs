using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models.Exceptions;

public sealed class PageNumberExceedsTotalNumberOfPagesException : Exception
{
    private PageNumberExceedsTotalNumberOfPagesException(
        [NotNull] int pageNumber,
        [NotNull] int totalNumberOfPages) 
        : base($"Page number ({pageNumber}) exceeds the total number of pages ({totalNumberOfPages}).")
    {
        PageNumber = pageNumber;
        TotalNumberOfPages = totalNumberOfPages;
    }

    public int PageNumber { get; }
    public int TotalNumberOfPages { get; }

    public static void ThrowIfNecessary(
        [NotNull] int pageNumber,
        [NotNull] int totalNumberOfPages)
    {
        if (pageNumber > totalNumberOfPages)
        {
            throw new PageNumberExceedsTotalNumberOfPagesException(pageNumber, totalNumberOfPages);
        }
    }
}