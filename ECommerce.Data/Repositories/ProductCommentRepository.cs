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
    public class ProductCommentRepository: Repository<ProductComment>,IProductCommentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductComment> _dbSet;
        public ProductCommentRepository(ECommerceDbContext context):base(context)
        {
            _context = context;
            _dbSet = context.Set<ProductComment>();
        }

        public async Task<IEnumerable<ProductComment>> GetAllWithProductWithUserAsync()
        {
            return await _dbSet.Include(x=>x.Product).Include(x=>x.OwnerUser).Include(x=>x.ModeratorUser).Where(x=>true).ToListAsync();
        }

        public async Task<IEnumerable<ProductComment>> GetAllWithProductWithUserAsync(Expression<Func<ProductComment, bool>> expression)
        {
            return await _dbSet.Include(x => x.Product).Include(x => x.OwnerUser).Include(x => x.ModeratorUser).Where(expression).ToListAsync();
        }

    }
}
