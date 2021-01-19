using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class OrderDetail: Entity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public OrderDetailStatusEnum Status { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}
