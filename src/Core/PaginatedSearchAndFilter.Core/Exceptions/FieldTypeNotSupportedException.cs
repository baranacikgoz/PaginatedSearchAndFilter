using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Exceptions;
public class FieldTypeNotSupportedException : Exception
{
    public FieldTypeNotSupportedException(
        [NotNull] Type classType,
        [NotNull] Type fieldType,
        [NotNull] string where)
        : base($"The field type ({fieldType.Name}) of the class ({classType.Name}) in ({where}).")
    {
        ClassType = classType;
        FieldType = fieldType;
        Where = where;
    }
    public Type ClassType { get; }
    public Type FieldType { get; }
    public string Where { get; } // To tell where. Eg. "AdvancedSearch.Field"
}
