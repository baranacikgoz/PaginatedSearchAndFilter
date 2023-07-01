using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedFilterAndSearch.Exceptions;

public class PageSizeExceedsTotalNumberOfDataException : Exception
{
    public PageSizeExceedsTotalNumberOfDataException(int pageSize, int totalNumberOfData) : base($"Page size ({pageSize}) exceeds the total number of data ({totalNumberOfData}).]")
    {
    }
}