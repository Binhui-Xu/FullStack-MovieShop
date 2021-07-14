using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.RepositoryInterface
{
    public interface IAsyncRepository<T> where T:class
    {
        //common CRUD operations that will be used by all other repositories
        //async/await
        Task<T> GetById(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter=null);
    }
}
