using LectorUniversal.Shared;

namespace LectorUniversal.Server.Service.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public BookServices(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWorkRepository = unitOfWork;
        }
        public async Task AddBooksAsync(Book entity)
        {
            await _unitOfWorkRepository.BookRepository.AddBook(entity);
        }

        public async Task<bool> BookExistAsync(int Id)
        {
            return await _unitOfWorkRepository.BookRepository.BooksExistsAsync(Id);
        }

        public async Task DeleteBooksAsync(Book entity)
        {
            await _unitOfWorkRepository.BookRepository.DeleteBook(entity);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _unitOfWorkRepository.BookRepository.GetAllBooks();
            return books.ToList();
        }

        public async Task<Book> GetBookAsync(int Id)
        {
            Book book = await _unitOfWorkRepository.BookRepository.GetBook(Id);
            return book;
        }

        public async Task ModifyBooksAsync(Book entity)
        {
            await _unitOfWorkRepository.BookRepository.ModifyBook(entity);
        }

        public async Task<bool> SaveBooksAsync()
        {
            return await _unitOfWorkRepository.BookRepository.SaveBookDbAsync();
        }
    }
}
