using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity :class//niye Entity değil de class?
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> AnyAsync();
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<TEntity, bool>> expression);
        Task DeleteAsync(int id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task SaveAsync();
        Task<TEntity> UpdateAsync(TEntity entity);

    }
}
