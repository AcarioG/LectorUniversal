using LectorUniversal.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LectorUniversal.Server.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        public string ErrorMessage { get; set; }
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task Delete(T entity)
        {
            await Task.Run(() =>
            {
                dbSet.Remove(entity).State = EntityState.Deleted;
            });
        }

        public async Task<T> Get(int Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            await Task.Run(() =>
            {
                _context.Update(entity).State = EntityState.Modified;
            });
        }

        public async Task<bool> Save()
        {
            try
            {
                return await  _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                return false;
            }
        }
    }
}
