namespace PaginatedSearchAndFilter.Models.Exceptions;

public class FilterOperatorNotValidException : Exception
{
    public FilterOperatorNotValidException(string value) : base($"Provided value ({value}) is not a valid filter operator.]")
    {
    }
}