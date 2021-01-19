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
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(ECommerceDbContext context):base(context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }
        public async Task<IEnumerable<Product>> GetAllWithProductCategoryAsync(Expression<Func<Product, bool>> expression)
        {
            return await _dbSet.Include("ProductCategory").Where(expression).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var temp = await GetAsync(product.Id);
            product.UserId = temp.UserId;
            product.UpdateDate = DateTime.Now;
            _context.Entry(temp).CurrentValues.SetValues(product);
            await SaveAsync();
            return temp;
        }

    }
}
