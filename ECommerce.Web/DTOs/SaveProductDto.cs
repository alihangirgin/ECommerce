using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class SaveProductDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string CoverImage { get; set; }
    }
}
