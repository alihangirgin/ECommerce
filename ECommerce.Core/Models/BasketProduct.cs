using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class BasketProduct:Entity
    {
        public int UserBasketId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public virtual UserBasket UserBasket { get; set; }
        public virtual Product Product { get; set; }
    }
}
