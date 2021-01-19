using ECommerce.Core.Models;
using ECommerce.Core.Repositories;
using ECommerce.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<OrderDetail> _dbSet;
        public OrderDetailRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<OrderDetail>();
        }

        public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            var temp = await GetAsync(orderDetail.Id);
            orderDetail.UserId = temp.UserId;
            orderDetail.UpdateDate = DateTime.Now;
            _context.Entry(temp).CurrentValues.SetValues(orderDetail);
            await SaveAsync();
            return temp;
        }
    }
}
