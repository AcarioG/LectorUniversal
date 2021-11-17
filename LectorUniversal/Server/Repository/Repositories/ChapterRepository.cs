using LectorUniversal.Server.Repository;
using LectorUniversal.Server.Data;
using LectorUniversal.Shared;

namespace LectorUniversal.Server.Repository
{
    public class ChapterRepository : BaseRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<Chapter>> GetAllChapters()
        {
            return await GetAll();
        }

        public async Task AddChapter(Chapter entity)
        {
            await Insert(entity);
        }

        public async Task<Chapter> GetChapter(int Id)
        {
            return await Get(Id);
        }

        public async Task ModifyChapter(Chapter entity)
        {
            await Update(entity);
        }

        public async Task DeleteChapter(Chapter entity)
        {
            await Delete(entity);
        }

        public async Task<bool> SaveChapterAsync()
        {
            return await Save();
        }
        public async Task<bool> ChapterExistAsync(int Id)
        {
            var chapter = await GetAllChapters();
            return chapter.Any(db => db.Id == Id);
        }

    }
}
