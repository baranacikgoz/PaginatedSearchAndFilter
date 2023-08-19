using Microsoft.Extensions.DependencyInjection;
using PaginatedSearchAndFilter.Core.Abstractions;
using PaginatedSearchAndFilter.Extensions;
using PaginatedSearchAndFilter.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatedSearchAndFilter.RawSql.PostgreSQL;

public static class PaginatedSearchAndFilterPostgresqlExtensions
{
    public static void UsePostgresqlSyntax(this PaginatedSearchAndFilterOptions options)
    {
        options.ConfigureServices(services =>
        {
            services.AddTransient<ISqlBuilder, PostgreSqlSyntaxSqlBuilder>();
        });
    }
}