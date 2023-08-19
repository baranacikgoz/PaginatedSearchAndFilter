using PaginatedSearchAndFilter.Core;
using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Models;
using System.Text;

namespace PaginatedSearchAndFilter.PostgreSQL;

public class PostgreSqlSyntaxSqlBuilder : ISqlBuilder
{
    private readonly IClassPropertyTypesCache _propertTypesCache;

    public PostgreSqlSyntaxSqlBuilder(IClassPropertyTypesCache propertTypesCache) => _propertTypesCache = propertTypesCache;

    public (string sql, ICollection<QueryParameter> parameters) Build(
        string baseQuery,
        string baseTableName,
        string? baseTableAlias,
        int pageNumber,
        int pageSize,
        ICollection<AdvancedSearch>? advancedSearches = null,
        CombinedAdvancedFilters? combinedAdvancedFilters = null)
    {
        EnsureInputsAreValid(advancedSearches, combinedAdvancedFilters);

        StringBuilder sqlBuilder = new();
        List<QueryParameter> parameters = new();

        return (sqlBuilder.ToString(), parameters);
    }

    private void EnsureInputsAreValid(IEnumerable<AdvancedSearch>? advancedSearches, CombinedAdvancedFilters? combinedAdvancedFilters)
        => throw new NotImplementedException();
}