using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models.Exceptions;

public sealed class ValueNegativeException : ArgumentOutOfRangeException
{
    private ValueNegativeException(
        [NotNull] string valueName,
        [NotNull] int value) 
        : base($"Value ({value}) is negative for {valueName}.")
    {
        ValueName = valueName;
        Value = value;
    }

    public string ValueName { get; }
    public int Value { get; }

    public static void ThrowIfNegative(
        [NotNull] int value,
        [NotNull] string valueName)
    {
        if (value < 0)
        {
            throw new ValueNegativeException(valueName, value);
        }
    }
}