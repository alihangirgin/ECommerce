using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductCommentWithUserAndProducDto:ProductCommentDto
    {
        public ProductDto Product { get; set; }
        public User OwnerUser { get; set; }
        public User ModeratorUser { get; set; }
    }
}
