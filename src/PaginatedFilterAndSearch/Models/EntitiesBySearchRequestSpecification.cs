using Ardalis.Specification;
using PaginatedFilterAndSearch.Extensions;

namespace PaginatedFilterAndSearch.Models;

public class EntitiesBySearchRequestSpecification<TEntity> : Specification<TEntity>
    where TEntity : class
{
    public SearchRequest SearchRequest { get; }

    public EntitiesBySearchRequestSpecification(SearchRequest request)
    {
        SearchRequest = request;
        Query.ApplySearchRequest(request);
    }
}

public class EntitiesBySearchRequestSpecification<TEntity, TDestination> : Specification<TEntity, TDestination>
    where TEntity : class
{
    public SearchRequest SearchRequest { get; }

    public EntitiesBySearchRequestSpecification(SearchRequest request)
    {
        SearchRequest = request;
        Query.ApplySearchRequest(request);
    }
}