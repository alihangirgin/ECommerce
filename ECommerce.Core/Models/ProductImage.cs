using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class ProductImage:Entity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
