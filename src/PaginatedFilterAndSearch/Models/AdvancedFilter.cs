using PaginatedFilterAndSearch.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Models;

public class AdvancedFilter
{
    public AdvancedFilter(
        [DisallowNull, NotNull] string field,
        [DisallowNull, NotNull] string @operator,
        [DisallowNull, NotNull] string logic,
        string? value = null,
        IEnumerable<AdvancedFilter>? filters = null)
    {
        FilterOperator.EnsureValid(@operator);
        FilterLogic.EnsureValid(logic);

        Field = field;
        Operator = @operator;
        Value = value;
        Logic = logic;
        Filters = filters;
    }

    public string Field { get; }
    public string Operator { get; }
    public object? Value { get; }
    public string Logic { get; }
    public IEnumerable<AdvancedFilter>? Filters { get; }
}

public static class FilterOperator
{
    public const string EQ = "eq";
    public const string NEQ = "neq";
    public const string LT = "lt";
    public const string LTE = "lte";
    public const string GT = "gt";
    public const string GTE = "gte";
    public const string STARTSWITH = "startswith";
    public const string ENDSWITH = "endswith";
    public const string CONTAINS = "contains";

    public static bool EnsureValid(string value)
        => value switch
        {
            EQ => true,
            NEQ => true,
            LT => true,
            LTE => true,
            GT => true,
            GTE => true,
            STARTSWITH => true,
            ENDSWITH => true,
            CONTAINS => true,
            _ => throw new FilterOperatorNotValidException(value)
        };
}

public static class FilterLogic
{
    public const string AND = "and";
    public const string OR = "or";
    public const string XOR = "xor";

    public static bool EnsureValid(string value)
        => value switch
        {
            AND => true,
            OR => true,
            XOR => true,
            _ => throw new FilterLogicNotValidException(value)
        };
}