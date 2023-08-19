using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.Core;

public class QueryParameter
{
    public QueryParameter(string columnName, object value)
    {
        ColumnName = columnName;
        Value = value;
    }

    public string ColumnName { get; }
    public object Value { get; }
}