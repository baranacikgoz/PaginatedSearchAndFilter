using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedFilterAndSearch.Exceptions;

public class FilterLogicNotValidException : Exception
{
    public FilterLogicNotValidException(string value) : base($"Provided value ({value}) is not a valid filter logic.]")
    {
    }
}