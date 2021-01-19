using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithProductCategoryAsync(Expression<Func<Product, bool>> expression);
        Task<Product> UpdateProductAsync(Product product);
    }
}
