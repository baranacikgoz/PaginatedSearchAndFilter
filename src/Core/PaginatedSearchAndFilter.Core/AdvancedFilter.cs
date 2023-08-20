using PaginatedSearchAndFilter.Models.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PaginatedSearchAndFilter.Models;

public class CombinedAdvancedFilters
{
    public CombinedAdvancedFilters(
        [NotNull] ICollection<AdvancedFilter> advancedFilters,
        [NotNull] string logicOperator)
    {
        LogicOperators.Validate(logicOperator);

        AdvancedFilters = advancedFilters;
        LogicOperator = logicOperator;
    }

    public IEnumerable<AdvancedFilter> AdvancedFilters { get; }

    public string LogicOperator { get; }
}

public class AdvancedFilter
{
    public AdvancedFilter(
        [NotNull] string field,
        [NotNull] string @operator,
        [NotNull] string value)
    {
        FilterOperators.Validate(@operator);

        Field = field;
        Operator = @operator;
        Value = value;
    }

    public string Field { get; }
    public string Operator { get; }
    public object Value { get; }
}

public static class FilterOperators
{
    private static readonly HashSet<string> _validOperators
        = new() { "eq", "neq", "lt", "lte", "gt", "gte", "startswith", "endswith", "contains" };

    public static void Validate(string @operator)
    {
        if (!_validOperators.Contains(@operator))
        {
            throw new FilterOperatorNotValidException(@operator);
        }
    }
}

public static class LogicOperators
{
    private static readonly HashSet<string> _validOperators
        = new() { "and", "or", "xor" };

    public static void Validate(string @operator)
    {
        if (!_validOperators.Contains(@operator))
        {
            throw new FilterOperatorNotValidException(@operator);
        }
    }
}