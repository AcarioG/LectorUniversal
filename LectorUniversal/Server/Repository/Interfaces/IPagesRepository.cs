using LectorUniversal.Shared;

namespace LectorUniversal.Server.Repository
{
    public interface IPagesRepository : IBaseRepository<Page>
    {
        Task<IEnumerable<Page>> GetAllPagesAsync();
        Task AddPage(Page entity);
        Task ModifyPage(Page entity);
        Task DeletePage(Page entity);
        Task<bool> SavePageAsync();
    }
}
