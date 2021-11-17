using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorUniversal.Server.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Save();
    }
}
