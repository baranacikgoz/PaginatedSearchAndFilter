using Ardalis.Specification;
using PaginatedFilterAndSearch.Interfaces;
using PaginatedSearchAndFilter.Models;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Specification.Extensions;

public static class SpecificationBuilderExtensions
{
    public static ISearchRequestAppliedSpecificationBuilder<T> ApplySearchRequest<T>(
        [NotNull] this ISpecificationBuilder<T> query,
        [NotNull] SearchRequest request)
            => new SearchRequestAppliedSpecificationBuilder<T>(
                query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ApplyAdvancedSearches(request.AdvancedSearches)
                .ApplyCombinedAdvancedFilter(request.CombinedAdvancedFilters)
                .ApplyOrderBy(request.OrderBys)
                .Specification,
                request);

    private static ISpecificationBuilder<T> ApplyPagination<T>(this ISpecificationBuilder<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber > 1)
        {
            query = query.Skip((pageNumber - 1) * pageSize);
        }

        return query.Take(pageSize);
    }

    private static ISpecificationBuilder<T> ApplyAdvancedSearches<T>(this ISpecificationBuilder<T> specificationBuilder, IEnumerable<AdvancedSearch>? advancedSearches)
    {
        throw new NotImplementedException();
    }

    private static ISpecificationBuilder<T> ApplyCombinedAdvancedFilter<T>(this ISpecificationBuilder<T> specificationBuilder, CombinedAdvancedFilters? combinedAdvancedFilters)
    {
        throw new NotImplementedException();
    }

    private static ISpecificationBuilder<T> ApplyOrderBy<T>(this ISpecificationBuilder<T> specificationBuilder, ICollection<OrderBy>? orderByFields)
    {
        throw new NotImplementedException();
    }
}