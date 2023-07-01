using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedFilterAndSearch.Exceptions;

public class FilterOperatorNotValidException : Exception
{
    public FilterOperatorNotValidException(string value) : base($"Provided value ({value}) is not a valid filter operator.]")
    {
    }
}