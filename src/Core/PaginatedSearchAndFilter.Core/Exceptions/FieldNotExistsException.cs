using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.Core.Exceptions;
public class FieldNotExistException : Exception
{
    public FieldNotExistException(
        [NotNull] Type classType, 
        [NotNull] string fieldName)
        : base($"Field ({fieldName}) not exists in the cache for the type ({classType.Name})")
    {

        ClassType = classType;
        FieldName = fieldName;
    }

    public Type ClassType { get; }
    public String FieldName { get; }

}