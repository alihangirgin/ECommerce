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
    public class ProductCategoryRepository: Repository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductCategory> _dbSet;
        public ProductCategoryRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<ProductCategory>();
        }
        public async Task<IEnumerable<ProductCategory>> GetAllWithParentCategoryAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            return await _dbSet.Include(x=>x.ParentCategory).Where(expression).ToListAsync();
        }

        public async Task<ProductCategory> GetWithParentCategoryAsync(int id)
        {
            return await _dbSet.Include(x=>x.ParentCategory).FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<ProductCategory> GetWithParentCategoryAsync(int? id)
        {
            return await _dbSet.Include(x => x.ParentCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            var temp = await GetAsync(productCategory.Id);
            productCategory.UserId = temp.UserId;
            productCategory.UpdateDate = DateTime.Now;
            _context.Entry(temp).CurrentValues.SetValues(productCategory);
            await SaveAsync();
            return temp;
        }

    }
}
