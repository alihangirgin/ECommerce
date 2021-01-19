using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            Products = new Collection<Product>();
            Categories = new Collection<ProductCategory>();
            OrderDetails = new Collection<OrderDetail>();
            AcceptedProductComments = new Collection<ProductComment>();
            AddedProductComments = new Collection<ProductComment>();
            ProductImages = new Collection<ProductImage>();
            UserAddresses = new Collection<UserAddresses>();
            UserBaskets = new Collection<UserBasket>();
        }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> Categories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductComment> AcceptedProductComments { get; set; }
        public virtual ICollection<ProductComment> AddedProductComments { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        public virtual ICollection<UserBasket> UserBaskets { get; set; }
        public virtual UserDetail UserDetail { get; set; }

    }
}
