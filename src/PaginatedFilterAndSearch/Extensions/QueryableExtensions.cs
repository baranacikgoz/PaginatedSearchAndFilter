using PaginatedFilterAndSearch.Abstractions;
using PaginatedFilterAndSearch.Models;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Extensions;

public static class QueryableExtensions
{
    public static ISearchRequestAppliedQueryable<T> ApplySearchReuqest<T>(
        [DisallowNull, NotNull] this IQueryable<T> query,
        [DisallowNull, NotNull] SearchRequest request)
        => new SearchRequestAppliedQueryable<T>(
                query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ApplySearchByKeyword(request.Keyword)
                .ApplyAdvancedSearch(request.AdvancedSearch)
                .ApplyAdvancedFilter(request.AdvancedFilter)
                .ApplyOrderBy(request.OrderBy), request);

    private static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber > 1)
        {
            query = query.Skip((pageNumber - 1) * pageSize);
        }

        return query.Take(pageSize);
    }

    private static IQueryable<T> ApplySearchByKeyword<T>(this IQueryable<T> specificationBuilder, string? keyword)
    {
        throw new NotImplementedException();
    }

    private static IQueryable<T> ApplyAdvancedSearch<T>(this IQueryable<T> specificationBuilder, AdvancedSearch? advancedSearch)
    {
        throw new NotImplementedException();
    }

    private static IQueryable<T> ApplyAdvancedFilter<T>(this IQueryable<T> specificationBuilder, AdvancedFilter? filter)
    {
        throw new NotImplementedException();
    }

    private static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> specificationBuilder, ICollection<string>? orderByFields)
    {
        throw new NotImplementedException();
    }
}