using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class MainBarViewModel
    {
        public IEnumerable<ProductCategoryDto> ProductCategories { get; set; }
        public string SearchText { get; set; }
    }
}
