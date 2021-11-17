using LectorUniversal.Shared;

namespace LectorUniversal.Server.Service
{
    public interface IChapterServices
    {
        Task<IEnumerable<Chapter>> GetAllChaptersAsync();
        Task<Chapter> GetChapterAsync(int Id);
        Task AddChaptersAsync(Chapter entity);
        Task ModifyChaptersAsync(Chapter entity);
        Task DeleteChaptersAsync(Chapter entity);
        Task<bool> SaveChaptersAsync();
        Task<bool> ChapterExistAsync(int Id);
    }
}
