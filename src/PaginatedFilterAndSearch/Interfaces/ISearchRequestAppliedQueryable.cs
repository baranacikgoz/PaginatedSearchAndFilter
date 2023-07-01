using PaginatedFilterAndSearch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PaginatedFilterAndSearch.Abstractions;

public interface ISearchRequestAppliedQueryable<out T> : IQueryable<T>
{
    public SearchRequest SearchRequest { get; }
}

public class SearchRequestAppliedQueryable<T> : ISearchRequestAppliedQueryable<T>
{
    public SearchRequestAppliedQueryable(IQueryable<T> queryable, SearchRequest searchRequest)
    {
        Queryable = queryable;
        SearchRequest = searchRequest;
        ElementType = Queryable.ElementType;
        Expression = Queryable.Expression;
        Provider = Queryable.Provider;
    }

    public SearchRequest SearchRequest { get; }
    public IQueryable<T> Queryable { get; }

    public Type ElementType { get; }

    public Expression Expression { get; }

    public IQueryProvider Provider { get; }

    public IEnumerator<T> GetEnumerator() => Queryable.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}