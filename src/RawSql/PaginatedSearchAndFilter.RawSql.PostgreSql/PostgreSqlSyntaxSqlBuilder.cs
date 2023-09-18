using PaginatedSearchAndFilter.Core;
using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Core.Exceptions;
using PaginatedSearchAndFilter.Models;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PaginatedSearchAndFilter.PostgreSQL;

public class PostgreSqlSyntaxSqlBuilder : ISqlBuilder
{
    private readonly IClassFieldsCache _classFieldsCache;

    public PostgreSqlSyntaxSqlBuilder(IClassFieldsCache classFieldsCache) => _classFieldsCache = classFieldsCache;

    async Task<(string sql, ICollection<QueryParameter> parameters)> Build<T>(
        [NotNull] string baseQuery,
        [NotNull] string baseTableName,
                  string? baseTableAlias,
        [NotNull] int pageNumber,
        [NotNull] int pageSize,
                  ICollection<AdvancedSearch>? advancedSearches = null,
                  CombinedAdvancedFilters? combinedAdvancedFilters = null)
    {
        await EnsureInputsAreValid<T>(advancedSearches, combinedAdvancedFilters).ConfigureAwait(false);

        StringBuilder sqlBuilder = new();
        List<QueryParameter> parameters = new();

        AppendBaseQuery(baseQuery, sqlBuilder);
        await AppendAdvancedSearch<T>(baseTableAlias, advancedSearches, sqlBuilder, parameters).ConfigureAwait(false);
        // TODO AppendCombinedAdvancedFilters
        // TODO AppendOrderBys
        // TODO AppendPaging


        return (sqlBuilder.ToString(), parameters);
    }

    private async Task AppendAdvancedSearch<T>(string? baseTableAlias, ICollection<AdvancedSearch>? advancedSearches, StringBuilder sqlBuilder, List<QueryParameter> parameters)
    {
        if (advancedSearches is not null && advancedSearches.Count > 0)
        {
            sqlBuilder.Append(" WHERE ");


            int i = 0;
            var enumarator = advancedSearches.GetEnumerator();
            while (enumarator.MoveNext())
            {
                AdvancedSearch advancedSearch = enumarator.Current;
                string field = advancedSearch.Field;
                object value = advancedSearch.Value;

                string fieldAsTableColumn = baseTableAlias is null
                                      ? @$"""{field}"""
                                      : @$"{baseTableAlias}.""{field}""";

                string paramName = $"Value{i}";

                Type columnType = await _classFieldsCache.GetFieldTypeAsync<T>(field).ConfigureAwait(false);

                if (columnType == typeof(string))
                {
                    parameters.Add(new(paramName, $"%{value}%"));

                    sqlBuilder.Append(fieldAsTableColumn)
                              .Append($" LIKE @{paramName} OR ");


                }
                else if (columnType == typeof(int) || columnType == typeof(double) || columnType == typeof(long) || columnType == typeof(float))
                {
                    parameters.Add(new(paramName, value));
                    sqlBuilder.Append(fieldAsTableColumn)
                              .Append($" = @{paramName} OR ");
                }
                else
                {
                    throw new FieldTypeNotSupportedException(typeof(T), columnType, "AdvancedSearch.Field");
                }

                i++;
            }

            sqlBuilder.Remove(sqlBuilder.Length - 4, 4); // Remove the last " OR "
        }
    }

    private static void AppendBaseQuery(string baseQuery, StringBuilder sqlBuilder) => sqlBuilder.Append(baseQuery);
    private async Task EnsureInputsAreValid<T>(ICollection<AdvancedSearch>? advancedSearches, CombinedAdvancedFilters? combinedAdvancedFilters)
    {
        if(advancedSearches is null && combinedAdvancedFilters is null)
        {
            return;
        }

        var advancedSearchFields = advancedSearches?.Select(a => a.Field) ?? Enumerable.Empty<string>();
        var combinedFilterFields = combinedAdvancedFilters?.AdvancedFilters.Select(c => c.Field) ?? Enumerable.Empty<string>();

        HashSet<string> distinctFields = new(advancedSearchFields.Concat(combinedFilterFields));

        Task[] tasks = distinctFields
            .Select(_classFieldsCache.EnsureFieldExistsAsync<T>)
            .ToArray();

        try
        {
            await Task.WhenAll(tasks).ConfigureAwait(false);

        }catch (AggregateException ex) when (ex.InnerExceptions.All(ie => ie is FieldNotExistException))
        {
            throw ex.InnerExceptions[0]; // Maybe create a new exception type and provide all not-valid fields??
        }
    }

}