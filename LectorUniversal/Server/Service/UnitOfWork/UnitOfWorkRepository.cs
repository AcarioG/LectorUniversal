using LectorUniversal.Server.Data;
using LectorUniversal.Server.Repository;

namespace LectorUniversal.Server.Service.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IChapterRepository ChapterRepository { get; }

        public IBooksRepository BookRepository { get; }

        public IPagesRepository PageRepository { get; }
        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            BookRepository = new BooksRepository(context);
            PageRepository = new PagesRepository(context);
            ChapterRepository = new ChapterRepository(context);
        }
    }
}
