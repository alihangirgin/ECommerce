using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region UserBasket

        public async Task<UserBasket> AddBasket()
        {
            UserBasket newUserBasket = new UserBasket();
            //newProduct.UserId = _userService.GetUser().Id; 
            newUserBasket.UserId = 1; // şimdilik 1
            newUserBasket.Status = 0;
            await _unitOfWork.UserBaskets.AddAsync(newUserBasket);
            await _unitOfWork.CommitAsync();
            return newUserBasket;
        }

        public async Task DeleteBasket(int id)
        {
            await _unitOfWork.UserBaskets.DeleteAsync(id);
        }

        public async Task<UserBasket> GetBasketById(int id)
        {
            return await _unitOfWork.UserBaskets.GetAsync(id);
        }

        public async Task<IEnumerable<UserBasket>> GetUsersOrderedBasketList()
        {
            //var userId = _userService.GetUser().Id; 
            var userId = 1; // şimdilik 1
            return await _unitOfWork.UserBaskets.GetAllAsync(x => x.UserId == userId && x.Status == UserBasketStatusEnum.Ordered && x.DeleteDate == null);
        }

        public async Task<UserBasket> GetUsersNonOrderedBasket()
        {
            //var userId = _userService.GetUser().Id; 
            var userId = 1; // şimdilik 1
            return await _unitOfWork.UserBaskets.GetAsync(x => x.UserId == userId && x.Status == UserBasketStatusEnum.NewlyCreated && x.DeleteDate == null);
        }

        #endregion


        #region BasketProduct

        public async Task<BasketProduct> AddBasketProduct(int productId)
        {
            var userBasket = await GetUsersNonOrderedBasket();
            if (userBasket == null)
            {
                userBasket = await AddBasket();
            }

            var basketProduct = await GetBasketProductByUserBasketIdAndProductId(userBasket.Id, productId);
            if (basketProduct != null)
            {
                var incrementedProductCount = basketProduct.ProductCount + 1;
                await UpdateBasketProductCount(userBasket.Id, productId, incrementedProductCount);
            }
            else
            {
                BasketProduct newBasketProduct = new BasketProduct();
                newBasketProduct.ProductId = productId;
                newBasketProduct.UserBasketId = userBasket.Id;
                newBasketProduct.ProductCount = 1;

                await _unitOfWork.BasketProducts.AddAsync(newBasketProduct);
                await _unitOfWork.CommitAsync();

                return newBasketProduct;
            }
            return basketProduct;
        }

        public async Task<BasketProduct> UpdateBasketProductCount(int userBasketId, int productId, int productCount)
        {
            var basketProduct = await GetBasketProductByUserBasketIdAndProductId(userBasketId, productId);
            if (basketProduct != null)
            {
                basketProduct.ProductCount = productCount;
                await _unitOfWork.BasketProducts.UpdateAsync(basketProduct);
                await _unitOfWork.CommitAsync();
            }
            return basketProduct;
        }

        public async Task DeleteBasketProduct(int id)
        {
            await _unitOfWork.BasketProducts.DeleteAsync(id);
        }

        public async Task<BasketProduct> GetBasketProductById(int Id)
        {
            return await _unitOfWork.BasketProducts.GetAsync(x => x.Id == Id);
        }

        public async Task<BasketProduct> GetBasketProductByUserBasketIdAndProductId(int userBasketId, int productId)
        {
            return await _unitOfWork.BasketProducts.GetAsync(x => x.UserBasketId==userBasketId && x.ProductId==productId);
        }


        public async Task<IEnumerable<BasketProduct>> GetBasketProductsByUserBasketId(int userBasketId)
        {
            return await _unitOfWork.BasketProducts.GetAllWithProductAsync(x => x.UserBasketId == userBasketId);
        }

        public async Task<IEnumerable<BasketProduct>> GetUsersBasketProducts()
        {
            var userBasket = await GetUsersNonOrderedBasket();
            IEnumerable<BasketProduct> basketProducts = new List<BasketProduct>();
            if (userBasket != null)
            {
                basketProducts = await GetBasketProductsByUserBasketId(userBasket.Id);
            }

            return basketProducts;
        }

        #endregion






    }
}
