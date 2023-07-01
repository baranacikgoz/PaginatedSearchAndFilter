using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using PaginatedFilterAndSearch.Abstractions;
using PaginatedFilterAndSearch.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace PaginatedFilterAndSearch.Extensions;

public static class EFCoreIntegrationExtensions
{
    public static async Task<PaginationResponse<TDestination>> PaginateBySpecAsync<T, TDestination>(
        [DisallowNull, NotNull] this IReadRepositoryBase<T> repository,
        [DisallowNull, NotNull] EntitiesBySearchRequestSpecification<T, TDestination> specification,
        CancellationToken cancellationToken = default)
        where T : class
    {
        int count = await repository.CountAsync(specification, cancellationToken).ConfigureAwait(false);
        var list = await repository.ListAsync(specification, cancellationToken).ConfigureAwait(false);

        return new PaginationResponse<TDestination>(list, count, specification.SearchRequest.PageNumber, specification.SearchRequest.PageSize);
    }

    public static async Task<PaginationResponse<T>> PaginateBySpecAsync<T>(
        [DisallowNull, NotNull] this IReadRepositoryBase<T> repository,
        [DisallowNull, NotNull] EntitiesBySearchRequestSpecification<T> specification,
        CancellationToken cancellationToken = default)
        where T : class
    {
        int count = await repository.CountAsync(specification, cancellationToken).ConfigureAwait(false);
        var list = await repository.ListAsync(specification, cancellationToken).ConfigureAwait(false);

        return new PaginationResponse<T>(list, count, specification.SearchRequest.PageNumber, specification.SearchRequest.PageSize);
    }

    public static async Task<PaginationResponse<T>> PaginateAsync<T>(
        [DisallowNull, NotNull] this ISearchRequestAppliedQueryable<T> queryable,
        CancellationToken cancellationToken = default)
    {
        int count = await queryable.CountAsync(cancellationToken).ConfigureAwait(false);
        var list = await queryable.ToListAsync(cancellationToken).ConfigureAwait(false);

        return new PaginationResponse<T>(list, count, queryable.SearchRequest.PageNumber, queryable.SearchRequest.PageSize);
    }

    public static async Task<PaginationResponse<TDestination>> PaginateAsync<T, TDestination>(
        [DisallowNull, NotNull] this ISearchRequestAppliedQueryable<T> queryable,
        [DisallowNull, NotNull] Expression<Func<T, TDestination>> selector,
        CancellationToken cancellationToken = default)
    {
        int count = await queryable.CountAsync(cancellationToken).ConfigureAwait(false);
        var list = await queryable.Select(selector).ToListAsync(cancellationToken).ConfigureAwait(false);

        return new PaginationResponse<TDestination>(list, count, queryable.SearchRequest.PageNumber, queryable.SearchRequest.PageSize);
    }
}