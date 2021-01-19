using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class ProductCommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ModeratorUserId { get; set; }
        public int ProductId { get; set; }
        public bool IsApproved { get; set; }
        public string CommentText { get; set; }
    }
}
