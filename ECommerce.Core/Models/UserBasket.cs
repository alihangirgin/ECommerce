using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class UserBasket : Entity
    {
        public UserBasket()
        {
            Orders = new Collection<Order>();
            BasketProducts = new Collection<BasketProduct>();
        }
        public int UserId { get; set; }
        public UserBasketStatusEnum Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
