using LectorUniversal.Shared;

namespace LectorUniversal.Server.Service
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(int Id);
        Task AddBooksAsync(Book entity);
        Task ModifyBooksAsync(Book entity);
        Task DeleteBooksAsync(Book entity);
        Task<bool> SaveBooksAsync();
        Task<bool> BookExistAsync(int Id);
    }
}
