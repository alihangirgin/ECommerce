using ECommerce.Core.Models;
using ECommerce.Core.Repositories;
using ECommerce.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        //public TEntity Add(TEntity model)
        //{
        //    model.CreateDate = DateTime.Now;
        //    _dbSet.Add(model);
        //    Save();
        //    return model;
        //}
        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        //public async Task<TEntity> AddAsync(TEntity entity)
        //{
        //    entity.CreateDate = DateTime.Now;
        //    _dbSet.Add(entity);
        //    await SaveAsync();
        //    return entity;
        //}

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
            //await SaveAsync();
            return entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                await AddAsync(item);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<bool> AnyAsync()
        {
            return await AnyAsync(x => true);
        }

        public async Task<long> CountAsync()
        {
            return await CountAsync(x => true);
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.LongCountAsync(expression);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            entity.DeleteDate = DateTime.Now;
            await UpdateAsync(entity);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
           return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var temp = await GetAsync(entity.Id);
            entity.UpdateDate = DateTime.Now;
            _context.Entry(temp).CurrentValues.SetValues(entity);
            //await SaveAsync();
            return temp;
        }

        //public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        //{
        //    return _dbSet.Where(expression);
        //}

    }
}
