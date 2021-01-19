using ECommerce.Core.Models;
using ECommerce.Core.Repositories;
using ECommerce.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class UserDetailRepository: Repository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(ECommerceDbContext context):base(context)
        {

        }
    }
}
