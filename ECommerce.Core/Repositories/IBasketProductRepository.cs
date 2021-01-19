using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IBasketProductRepository: IRepository<BasketProduct>
    {
        Task<IEnumerable<BasketProduct>> GetAllWithProductAsync(Expression<Func<BasketProduct, bool>> expression);
    }
}
