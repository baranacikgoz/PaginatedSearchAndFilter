namespace PaginatedSearchAndFilter.Models.Exceptions;

public class PageSizeExceedsTotalNumberOfDataException : Exception
{
    public PageSizeExceedsTotalNumberOfDataException(int pageSize, int totalNumberOfData) : base($"Page size ({pageSize}) exceeds the total number of data ({totalNumberOfData}).]")
    {
    }
}