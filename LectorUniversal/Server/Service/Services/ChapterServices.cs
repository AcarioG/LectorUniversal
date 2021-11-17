using LectorUniversal.Shared;

namespace LectorUniversal.Server.Service.Services
{
    public class ChapterServices : IChapterServices
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public ChapterServices(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWorkRepository = unitOfWork;
        }

        public async Task AddChaptersAsync(Chapter entity)
        {
            await _unitOfWorkRepository.ChapterRepository.AddChapter(entity);
        }

        public async Task<bool> ChapterExistAsync(int Id)
        {
            return await _unitOfWorkRepository.ChapterRepository.ChapterExistAsync(Id);
        }

        public async Task DeleteChaptersAsync(Chapter entity)
        {
            await _unitOfWorkRepository.ChapterRepository.DeleteChapter(entity);
        }

        public async Task<IEnumerable<Chapter>> GetAllChaptersAsync()
        {
            var chapters = await _unitOfWorkRepository.ChapterRepository.GetAllChapters();
            return chapters.ToList();
        }

        public async Task<Chapter> GetChapterAsync(int Id)
        {
            Chapter chapter = await _unitOfWorkRepository.ChapterRepository.GetChapter(Id);
            return chapter;
        }

        public async Task ModifyChaptersAsync(Chapter entity)
        {
            await _unitOfWorkRepository.ChapterRepository.ModifyChapter(entity);
        }

        public async Task<bool> SaveChaptersAsync()
        {
            return await _unitOfWorkRepository.ChapterRepository.SaveChapterAsync();
        }
    }
}
