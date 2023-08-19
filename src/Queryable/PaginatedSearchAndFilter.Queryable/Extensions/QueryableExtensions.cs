using PaginatedFilterAndSearch.Queryable.Interfaces;
using PaginatedSearchAndFilter.Models;
using PaginatedSearchAndFilter.Queryable.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Queryable.Extensions;

public static class QueryableExtensions
{
    public static ISearchRequestAppliedQueryable<T> ApplySearchReuqest<T>(
        [DisallowNull, NotNull] this IQueryable<T> query,
        [DisallowNull, NotNull] SearchRequest request)
        => new SearchRequestAppliedQueryable<T>(
                query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ApplyAdvancedSearches(request.AdvancedSearches)
                .ApplyCombinedAdvancedFilters(request.CombinedAdvancedFilters)
                .ApplyOrderBy(request.OrderBys),
                request);

    private static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber > 1)
        {
            query = query.Skip((pageNumber - 1) * pageSize);
        }

        return query.Take(pageSize);
    }

    private static IQueryable<T> ApplyAdvancedSearches<T>(this IQueryable<T> query, IEnumerable<AdvancedSearch>? advancedSearches)
    {
        throw new NotImplementedException();
    }

    private static IQueryable<T> ApplyCombinedAdvancedFilters<T>(this IQueryable<T> query, CombinedAdvancedFilters? combinedAdvancedFilters)
    {
        throw new NotImplementedException();
    }

    private static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> query, ICollection<OrderBy>? orderByFields)
    {
        if (orderByFields == null)
        {
            return query;
        }

        query = query.PrepareOrderBy(orderByFields);

        return query;
    }
}