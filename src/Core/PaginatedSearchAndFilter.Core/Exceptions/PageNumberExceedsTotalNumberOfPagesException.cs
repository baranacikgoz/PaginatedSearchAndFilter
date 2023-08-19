namespace PaginatedSearchAndFilter.Models.Exceptions;

public sealed class PageNumberExceedsTotalNumberOfPagesException : Exception
{
    private PageNumberExceedsTotalNumberOfPagesException(int pageNumber, int totalNumberOfPages) : base($"Page number ({pageNumber}) exceeds the total number of pages ({totalNumberOfPages}).]")
    {
    }

    public static void ThrowIfNecessary(int pageNumber, int totalNumberOfPages)
    {
        if (pageNumber > totalNumberOfPages)
        {
            throw new PageNumberExceedsTotalNumberOfPagesException(pageNumber, totalNumberOfPages);
        }
    }
}