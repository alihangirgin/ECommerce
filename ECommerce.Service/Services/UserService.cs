using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class UserService: IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public User GetUser()
        {
            var checkUser =  _httpContextAccessor.HttpContext.User;
            var dbUser = _userManager.GetUserAsync(checkUser).Result;
            if (dbUser != null)
            {
                User user = new User()
                {
                    Email = dbUser.Email,
                    UserName = dbUser.UserName,
                    Id = dbUser.Id

                };
                return user;
            }
            return null;

        }
    }
}
