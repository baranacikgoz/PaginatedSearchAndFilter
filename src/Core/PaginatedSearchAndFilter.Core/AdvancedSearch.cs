using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class AdvancedSearch
{
    public AdvancedSearch(
        [NotNull] string field, 
        [NotNull] object value)
    {
        Field = field;
        Value = value;
    }

    public string Field { get; }
    public object Value { get; }
}