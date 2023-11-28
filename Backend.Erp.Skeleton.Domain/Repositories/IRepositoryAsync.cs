using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Domain.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        ValueTask<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}