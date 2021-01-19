using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class Order:Entity
    {
        public Order()
        {
            OrderDetails = new Collection<OrderDetail>();
        }
        public int UserBasketId { get; set; }
        public int InvoiceAddressId { get; set; }
        public int DeliveryAddressId { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public bool PaymentStatus { get; set; } //-> paymentstatusenum ("Ödendi","Beklemede")
        public PaymentTypeEnum PaymentType { get; set; }
        public virtual UserBasket UserBasket { get; set; }
        public virtual UserAddresses InvoiceAddress { get; set; }
        public virtual UserAddresses DeliveryAddress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
