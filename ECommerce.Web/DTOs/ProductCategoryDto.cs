using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ProductCategoryDto ParentCategory { get; set; }
        public virtual IEnumerable<ProductCategoryDto> SubCategories { get; set; }
    }
}
