using System.Diagnostics.CodeAnalysis;

namespace PaginatedSearchAndFilter.Models;

public class OrderBy
{
    public OrderBy(
        [NotNull] string field,
        [NotNull] bool isDescending)
    {
        Field = field;
        IsDescending = isDescending;
    }

    public string Field { get; }
    public bool IsDescending { get; }
}