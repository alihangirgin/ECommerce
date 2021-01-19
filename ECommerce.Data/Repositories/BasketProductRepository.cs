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
    public class BasketProductRepository : Repository<BasketProduct>, IBasketProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<BasketProduct> _dbSet;
        public BasketProductRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<BasketProduct>();
        }
        public async Task<IEnumerable<BasketProduct>> GetAllWithProductAsync(Expression<Func<BasketProduct, bool>> expression)
        {
            return await _dbSet.Include(x => x.Product).Where(expression).ToListAsync();
        }
    }
}
