using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectorUniversal.Shared;
using LectorUniversal.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Repository
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await GetAll();
        }

        public async Task<Book> GetBook(int Id)
        {
            return await Get(Id);
        }

        public async Task AddBook(Book entity)
        {
            await Insert(entity);
        }

        public async Task ModifyBook(Book entity)
        {
            await Update(entity);
        }

        public async Task DeleteBook(Book entity)
        {
            await Delete(entity);
        }

        public async Task<bool> SaveBookDbAsync()
        {
            return await Save();
        }

        public async Task<bool> BooksExistsAsync(int Id)
        {
            var comics = await GetAllBooks();
            return comics.Any(db => db.Id == Id);
        }
    }
}
