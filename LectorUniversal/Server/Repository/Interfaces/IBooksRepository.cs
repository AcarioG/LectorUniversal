using LectorUniversal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Server.Repository
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int Id);
        Task AddBook(Book entity);
        Task ModifyBook(Book entity);
        Task DeleteBook(Book entity);
        Task<bool> SaveBookDbAsync();
        Task<bool> BooksExistsAsync(int Id);
    }
}
