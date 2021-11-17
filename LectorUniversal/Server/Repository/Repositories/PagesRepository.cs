using LectorUniversal.Shared;
using LectorUniversal.Server.Repository;
using LectorUniversal.Server.Data;

namespace LectorUniversal.Server.Repository
{
    public class PagesRepository : BaseRepository<Page>, IPagesRepository
    {
        public PagesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task AddPage(Page entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePage(Page entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Page>> GetAllPagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ModifyPage(Page entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SavePageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
