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
    public class ProductImageRepository:Repository<ProductImage>, IProductImageRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductImage> _dbSet;
        public ProductImageRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<ProductImage>();
        }
        public async Task<IEnumerable<ProductImage>> GetAllWithProductAndUserAsync()
        {
            return await _dbSet.Include(x => x.Product).Include(x => x.User).Where(x => true).ToListAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetAllWithProductAndUserAsync(Expression<Func<ProductImage, bool>> expression)
        {
            return await _dbSet.Include(x => x.Product).Include(x => x.User).Where(expression).ToListAsync();
        }

    }
}
