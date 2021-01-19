using ECommerce.Core.Repositories;
using ECommerce.Core.UnitOfWorks;
using ECommerce.Data.DataAccess;
using ECommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private BasketProductRepository _basketProductRepository;
        private CampaignSliderRepository _campaignSliderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private OrderRepository _orderRepository;
        private ProductCategoryRepository _productCategoryRepository;
        private ProductCommentRepository _productCommentRepository;
        private ProductImageRepository _productImageRepository;
        private ProductRepository _productRepository;
        private UserAddressesRepository _userAddressesRepository;
        private UserBasketRepository _userBasketRepository;
        private UserDetailRepository _userDetailRepository;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public IBasketProductRepository BasketProducts => _basketProductRepository = _basketProductRepository ?? new BasketProductRepository(_context);

        public ICampaignSliderRepository CampaignSliders => _campaignSliderRepository = _campaignSliderRepository ?? new CampaignSliderRepository(_context);

        public IOrderDetailRepository OrderDetails => _orderDetailRepository = _orderDetailRepository ?? new OrderDetailRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);

        public IProductCategoryRepository ProductCategories => _productCategoryRepository = _productCategoryRepository ?? new ProductCategoryRepository(_context);

        public IProductCommentRepository ProductComments => _productCommentRepository = _productCommentRepository ?? new ProductCommentRepository(_context);

        public IProductImageRepository ProductImages => _productImageRepository = _productImageRepository ?? new ProductImageRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IUserAddressesRepository UserAddresses => _userAddressesRepository = _userAddressesRepository ?? new UserAddressesRepository(_context);

        public IUserBasketRepository UserBaskets => _userBasketRepository = _userBasketRepository ?? new UserBasketRepository(_context);

        public IUserDetailRepository UserDetails => _userDetailRepository = _userDetailRepository ?? new UserDetailRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    
    }
}
