using LectorUniversal.Shared;

namespace LectorUniversal.Server.Repository
{
    public interface IChapterRepository : IBaseRepository<Chapter>
    {
        Task<IEnumerable<Chapter>> GetAllChapters();
        Task<Chapter> GetChapter(int Id);
        Task AddChapter(Chapter entity);
        Task ModifyChapter(Chapter entity);
        Task DeleteChapter(Chapter entity);
        Task<bool> SaveChapterAsync();
        Task<bool> ChapterExistAsync(int Id);
    }
}
