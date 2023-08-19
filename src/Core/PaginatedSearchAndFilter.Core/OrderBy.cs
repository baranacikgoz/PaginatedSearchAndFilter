namespace PaginatedSearchAndFilter.Models;

public class OrderBy
{
    public OrderBy(string field, bool isDescending)
    {
        Field = field;
        IsDescending = isDescending;
    }

    public string Field { get; }
    public bool IsDescending { get; }
}