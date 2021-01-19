using ECommerce.Core.Models;
using ECommerce.Core.Repositories;
using ECommerce.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class UserBasketRepository : Repository<UserBasket>, IUserBasketRepository
    {
        public UserBasketRepository(ECommerceDbContext context):base(context)
        {

        }
    }
}
