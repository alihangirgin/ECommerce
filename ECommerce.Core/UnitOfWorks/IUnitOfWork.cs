using ECommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBasketProductRepository BasketProducts { get; }
        ICampaignSliderRepository CampaignSliders { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IProductCategoryRepository ProductCategories { get; }
        IProductCommentRepository ProductComments { get; }
        IProductImageRepository ProductImages { get; }
        IProductRepository Products { get; }
        IUserAddressesRepository UserAddresses { get; }
        IUserBasketRepository UserBaskets { get; }
        IUserDetailRepository UserDetails { get; }
        Task<int> CommitAsync();
    }
}
