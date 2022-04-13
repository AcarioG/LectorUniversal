using LectorUniversal.Shared.DTOs;

namespace LectorUniversal.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.Records)
                .Take(pagination.Records);
        }
    }
}
