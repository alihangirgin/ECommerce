using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductCategoryWithParentCategoryDto:ProductCategoryDto
    {
        public ProductCategoryDto ParentCategory { get; set; }
    }
}
