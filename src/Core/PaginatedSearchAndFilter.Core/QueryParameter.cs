using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.Core;

public class QueryParameter
{
    public QueryParameter(
        [NotNull] string columnName,
        [NotNull] object value)
    {
        ColumnName = columnName;
        Value = value;
    }

    public string ColumnName { get; }
    public object Value { get; }
}