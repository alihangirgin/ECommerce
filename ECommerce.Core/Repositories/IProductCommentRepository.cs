using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IProductCommentRepository: IRepository<ProductComment>
    {
        Task<IEnumerable<ProductComment>> GetAllWithProductWithUserAsync();
        Task<IEnumerable<ProductComment>> GetAllWithProductWithUserAsync(Expression<Func<ProductComment, bool>> expression);
    }
}
