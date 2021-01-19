using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class UserAddresses : Entity
    {
        public UserAddresses()
        {
            OrderByDeliveryAddress = new Collection<Order>();
            OrderByInvoiceAddress = new Collection<Order>();
        }
        public int UserId { get; set; }
        public bool DefaultAddress { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressText { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> OrderByDeliveryAddress { get; set; }
        public virtual ICollection<Order> OrderByInvoiceAddress { get; set; }
    }
}
