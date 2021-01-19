using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IProductImageRepository: IRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetAllWithProductAndUserAsync();
        Task<IEnumerable<ProductImage>> GetAllWithProductAndUserAsync(Expression<Func<ProductImage, bool>> expression);
    }
}
