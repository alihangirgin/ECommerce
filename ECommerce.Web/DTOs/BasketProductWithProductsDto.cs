using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class BasketProductWithProductsDto:BasketProductDto
    {
        public virtual ProductDto Product { get; set; }
    }
}
