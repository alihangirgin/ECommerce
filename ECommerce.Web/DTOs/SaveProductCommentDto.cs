using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class SaveProductCommentDto
    {
        public int ProductId { get; set; }
        public string CommentText { get; set; }
    }
}
