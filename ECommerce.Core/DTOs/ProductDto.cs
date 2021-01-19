using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string CoverImage { get; set; }
    }
}
