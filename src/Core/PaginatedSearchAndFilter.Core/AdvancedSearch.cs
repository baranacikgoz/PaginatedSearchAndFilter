using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class AdvancedSearch
{
    public AdvancedSearch(string field, string keyword)
    {
        Fields = field;
        Keyword = keyword;
    }

    public string Fields { get; }
    public string Keyword { get; }
}