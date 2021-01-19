using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public ProductCategoryDto ProductCategory { get; set; }
        public List<String> CoverImages { get; set; }
    }
}
