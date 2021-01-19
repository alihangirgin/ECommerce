using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductWithProductCommentAndUserDto:ProductDto
    {
        public IEnumerable<ProductCommentDto> ProductComments { get; set; }
        public IEnumerable<ProductImageDto> ProductImages { get; set; }
        public User OwnerUser { get; set; }
        public User ModeratorUser { get; set; }

    }
}
