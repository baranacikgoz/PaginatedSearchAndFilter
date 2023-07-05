using PaginatedSearchAndFilter.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace PaginatedSearchAndFilter.Queryable.Extensions;
public static class OrderByBuilderExtensions
{
    public static IQueryable<T> PrepareOrderBy<T>([NotNull] this IQueryable<T> query, [NotNull] ICollection<OrderBy> orderByFields)
    {
        int index = 0;

        foreach (var orderByField in orderByFields)
        {
            query = query.PrepareOrderBy(orderByField, index);
            index++;
        }

        return query;
    }

    public static IQueryable<T> PrepareOrderBy<T>([NotNull] this IQueryable<T> query, [NotNull] OrderBy orderBy, int index = 0)
    {
        string command = orderBy.IsDescending ? "OrderByDescending" : "OrderBy";

        if (index > 0)
        {
            command = orderBy.IsDescending ? "ThenByDescending" : "ThenBy";
        }

        var type = typeof(T);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = GetMemberExpression(parameter, orderBy.Field);

        if (propertyAccess == null)
        {
            return query;
        }

        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var resultExpression = Expression.Call(typeof(System.Linq.Queryable), command, new Type[] { type, propertyAccess.Type },
                                      query.Expression, Expression.Quote(orderByExpression));
        return query.Provider.CreateQuery<T>(resultExpression);
    }

    private static Expression? GetMemberExpression(Expression param, [NotNull] string propertyName)
    {
        if (propertyName.Contains('.', StringComparison.CurrentCulture))
        {
            int index = propertyName.IndexOf('.', StringComparison.CurrentCulture);
            if (param.Type.GetProperty(propertyName[..index]) != null)
            {
                var subParam = Expression.Property(param, propertyName[..index]);
                return GetMemberExpression(subParam, propertyName[(index + 1)..]);
            }
            else
            {
                return null;
            }
        }

        return param.Type.GetProperty(propertyName) != null ? Expression.Property(param, propertyName) : (Expression?)null;
    }
}
