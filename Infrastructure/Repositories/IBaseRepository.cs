using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<bool> AnyDataExistAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddAllAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);

        // Extended functionality
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetPagedListAsync(int pageIndex, int pageSize);
        Task<IEnumerable<T>> GetSortedAsync(Expression<Func<T, object>> orderBy, bool ascending = true);
    }

}
