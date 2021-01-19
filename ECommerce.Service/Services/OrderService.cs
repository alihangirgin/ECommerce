using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketService _basketService;
        public OrderService(IUnitOfWork unitOfWork, IBasketService basketService)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetAsync(id);
        }

        public async Task<Order> PayOrder(int id)
        {
            var order = await GetOrderById(id);
            order.PaymentStatus = true;
            var paidOrder = await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CommitAsync();
            return paidOrder;
        }

        public async Task<IEnumerable<Order>> GetUserOrderList()
        {
            var basketList = await _basketService.GetUsersOrderedBasketList();
            var orderList = new List<Order>();
            foreach (var item in basketList)
            {
                var order = await _unitOfWork.Orders.GetAsync(x => x.UserBasketId == item.Id && x.DeleteDate==null);
                if (order != null)
                {
                    orderList.Add(order);
                }
            }

            return orderList;
        }

        public async Task<IEnumerable<Order>> GetOrderList()
        {
            return await _unitOfWork.Orders.GetAllAsync(x => x.DeleteDate == null);
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _unitOfWork.OrderDetails.GetAsync(id);
        }

        public async Task<OrderDetail> AddOrderDetail(OrderDetail newOrderDetail)
        {
            //newProduct.UserId = _userService.GetUser().Id; 
            newOrderDetail.UserId = 1; // şimdilik 1
            await _unitOfWork.OrderDetails.AddAsync(newOrderDetail);
            await _unitOfWork.CommitAsync();
            return newOrderDetail;
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var updatedOrder = await _unitOfWork.OrderDetails.UpdateOrderDetailAsync(orderDetail);
            await _unitOfWork.CommitAsync();
            return updatedOrder;
        }

        public async Task DeleteOrderDetail(int id)
        {
            await _unitOfWork.OrderDetails.DeleteAsync(id);
        }

    }
}
