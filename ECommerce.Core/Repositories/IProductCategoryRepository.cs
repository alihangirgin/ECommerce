using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetAllWithParentCategoryAsync(Expression<Func<ProductCategory, bool>> expression);
        Task<ProductCategory> GetWithParentCategoryAsync(int id);
        Task<ProductCategory> GetWithParentCategoryAsync(int? id);
        Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory productCategory);
    }
}
