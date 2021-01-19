using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class SaveProductCategoryDto
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> ProductCategoryList { get; set; }
    }
}
