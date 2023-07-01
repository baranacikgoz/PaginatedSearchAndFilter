using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedFilterAndSearch.Exceptions;

public sealed class PageNumberExceedsTotalNumberOfPagesException : Exception
{
    public PageNumberExceedsTotalNumberOfPagesException(int pageNumber, int totalNumberOfPages) : base($"Page number ({pageNumber}) exceeds the total number of pages ({totalNumberOfPages}).]")
    {
    }
}