namespace PaginatedSearchAndFilter.Models.Exceptions;

public sealed class ValueNegativeException : ArgumentOutOfRangeException
{
    private ValueNegativeException(string valueName, int value) : base($"Value ({value}) is negative for {valueName}.]")
    {
    }

    public static void ThrowIfNegative(int value, string valueName)
    {
        if (value < 0)
        {
            throw new ValueNegativeException(valueName, value);
        }
    }
}