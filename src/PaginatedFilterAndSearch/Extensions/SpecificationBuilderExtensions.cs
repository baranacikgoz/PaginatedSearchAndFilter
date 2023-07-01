using Ardalis.Specification;
using PaginatedFilterAndSearch.Interfaces;
using PaginatedFilterAndSearch.Models;
using System.Diagnostics.CodeAnalysis;

namespace PaginatedFilterAndSearch.Extensions;

public static class SpecificationBuilderExtensions
{
    public static ISearchRequestAppliedSpecificationBuilder<T> ApplySearchRequest<T>(
        [DisallowNull, NotNull] this ISpecificationBuilder<T> query,
        [DisallowNull, NotNull] SearchRequest request)
            => new SearchRequestAppliedSpecificationBuilder<T>(
                query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ApplySearchByKeyword(request.Keyword)
                .ApplyAdvancedSearch(request.AdvancedSearch)
                .ApplyAdvancedFilter(request.AdvancedFilter)
                .ApplyOrderBy(request.OrderBy).Specification,
                request);

    private static ISpecificationBuilder<T> ApplyPagination<T>(this ISpecificationBuilder<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber > 1)
        {
            query = query.Skip((pageNumber - 1) * pageSize);
        }

        return query.Take(pageSize);
    }

    private static ISpecificationBuilder<T> ApplySearchByKeyword<T>(this ISpecificationBuilder<T> specificationBuilder, string? keyword)
    {
        throw new NotImplementedException();
    }

    private static ISpecificationBuilder<T> ApplyAdvancedSearch<T>(this ISpecificationBuilder<T> specificationBuilder, AdvancedSearch? advancedSearch)
    {
        throw new NotImplementedException();
    }

    private static ISpecificationBuilder<T> ApplyAdvancedFilter<T>(this ISpecificationBuilder<T> specificationBuilder, AdvancedFilter? filter)
    {
        throw new NotImplementedException();
    }

    private static ISpecificationBuilder<T> ApplyOrderBy<T>(this ISpecificationBuilder<T> specificationBuilder, ICollection<string>? orderByFields)
    {
        throw new NotImplementedException();
    }
}