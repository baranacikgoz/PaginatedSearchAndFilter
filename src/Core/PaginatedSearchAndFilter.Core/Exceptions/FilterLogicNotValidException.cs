using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models.Exceptions;

public class FilterLogicNotValidException : Exception
{
    public FilterLogicNotValidException([NotNull] string value) 
        : base($"Provided value ({value}) is not a valid filter logic.")
    {
        Value = value;
    }

    public string Value { get; }
}