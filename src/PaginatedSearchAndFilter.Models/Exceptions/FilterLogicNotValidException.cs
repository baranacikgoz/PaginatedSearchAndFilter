namespace PaginatedSearchAndFilter.Models.Exceptions;

public class FilterLogicNotValidException : Exception
{
    public FilterLogicNotValidException(string value) : base($"Provided value ({value}) is not a valid filter logic.]")
    {
    }
}