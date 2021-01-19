using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class SaveProductImageDto
    {
        public int ProductId { get; set; }
        public IFormFile ProductImageFile { get; set; }
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
    }
}
