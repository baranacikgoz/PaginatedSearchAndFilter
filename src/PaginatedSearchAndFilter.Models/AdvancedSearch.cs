using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class AdvancedSearch
{
    public AdvancedSearch([DisallowNull, NotNull] IEnumerable<string> fields, string? keyword = null)
    {
        Fields = fields;
        Keyword = keyword;
    }

    public IEnumerable<string> Fields { get; }
    public string? Keyword { get; }
}