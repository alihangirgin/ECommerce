using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface IBasketService
    {
        Task<UserBasket> AddBasket();
        Task<BasketProduct> AddBasketProduct(int productId);
        Task<IEnumerable<UserBasket>> GetUsersOrderedBasketList();
        Task<UserBasket> GetUsersNonOrderedBasket();
        Task<IEnumerable<BasketProduct>> GetBasketProductsByUserBasketId(int userBasketId);
        Task<IEnumerable<BasketProduct>> GetUsersBasketProducts();
    }
}
