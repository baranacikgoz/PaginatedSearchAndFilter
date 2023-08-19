using Ardalis.Specification;
using PaginatedSearchAndFilter.Models;

namespace PaginatedFilterAndSearch.Interfaces;

public interface ISearchRequestAppliedSpecificationBuilder<T> : ISpecificationBuilder<T>
{
    public SearchRequest SearchRequest { get; }
}

public class SearchRequestAppliedSpecificationBuilder<T> : ISearchRequestAppliedSpecificationBuilder<T>
{
    public SearchRequestAppliedSpecificationBuilder(Specification<T> specification, SearchRequest searchRequest)
        => (Specification, SearchRequest) = (specification, searchRequest);

    public Specification<T> Specification { get; }
    public SearchRequest SearchRequest { get; }
}