using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductCategoryWithParentAndSubCategories:ProductCategoryDto
    {
        public ProductCategoryDto ParentCategory { get; set; }
        public IEnumerable<ProductCategoryDto> ParentCategories { get; set; }
        public IEnumerable<ProductCategoryDto> SubCategories { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
