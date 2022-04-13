using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Helpers
{
    public static class HttpContextExtentions
    {
        public async static Task InsertParameterInResponse<T> (this HttpContext context,IQueryable<T> queryable, int MaxRecords)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double countRecord = await queryable.CountAsync();
            double TotalRecords = Math.Ceiling(countRecord / MaxRecords);
            context.Response.Headers.Add("countRecord", countRecord.ToString());
            context.Response.Headers.Add("TotalRecords", TotalRecords.ToString());
        }
    }
}
