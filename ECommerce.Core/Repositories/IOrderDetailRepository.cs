using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IOrderDetailRepository: IRepository<OrderDetail>
    {
        Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail);
    }
}
