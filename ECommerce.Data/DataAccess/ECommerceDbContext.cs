using ECommerce.Core.Models;
using ECommerce.Data.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.DataAccess
{
    public class ECommerceDbContext : IdentityDbContext<User, Role, int>
    {
        public ECommerceDbContext() : base()
        {

        }
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<CampaignSlider> CampaignSliders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(new List<Role>()
            {
                new Role(){ Id=1, Name="User", NormalizedName="USER", CreateDate=DateTime.Now },
                new Role(){ Id=2, Name="Admin", NormalizedName="ADMIN", CreateDate=DateTime.Now }
            });

            /*Yg060535018..*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="y_gul06@hotmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="40254b97-9d3f-4ce3-9eab-72b1ee965991",
                    LockoutEnabled=true,
                    NormalizedEmail="y_gul06@hotmail.com",
                    NormalizedUserName="y_gul06",
                    PasswordHash="AQAAAAEAACcQAAAAEIoMkALFuhNj9mQQhpCMp96fFwZ1X2iL1WCUJLrhaNjHTiO6B/ihNzEZ+jvkQSsfbg==",
                    PhoneNumber="5412321962",
                    PhoneNumberConfirmed=true,
                    SecurityStamp="ZVBXXX6XI7A32A5HTK6SWN6PL5NROBDK",
                    UserName="y_gul06",
                    TwoFactorEnabled=false,
                    Id = 1,
                    CreateDate=DateTime.Now
                }
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new List<IdentityUserRole<int>>() {
                new IdentityUserRole<int>() { UserId = 1, RoleId = 1 } ,
                new IdentityUserRole<int>() { UserId = 1, RoleId = 2 }
            });




            builder.ApplyConfiguration(new BasketProductMap());
            builder.ApplyConfiguration(new CampaignSliderMap());
            builder.ApplyConfiguration(new OrderDetailMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductCategoryMap());
            builder.ApplyConfiguration(new ProductCommentMap());
            builder.ApplyConfiguration(new ProductImageMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new UserAddressesMap());
            builder.ApplyConfiguration(new UserBasketMap());
            builder.ApplyConfiguration(new UserDetailMap());
        }
    }

}
