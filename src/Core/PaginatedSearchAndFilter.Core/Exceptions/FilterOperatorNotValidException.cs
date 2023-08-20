using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models.Exceptions;

public class FilterOperatorNotValidException : Exception
{
    public FilterOperatorNotValidException([NotNull] string value) 
        : base($"Provided value ({value}) is not a valid filter operator.")
    {
        Value = value;
    }

    public string Value { get; }
}