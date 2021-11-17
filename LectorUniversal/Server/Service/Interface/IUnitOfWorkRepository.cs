using LectorUniversal.Server.Repository;

namespace LectorUniversal.Server.Service
{
    public interface IUnitOfWorkRepository
    {
        IChapterRepository ChapterRepository { get; }
        IBooksRepository BookRepository { get; }
        IPagesRepository PageRepository { get; }
    }
}
