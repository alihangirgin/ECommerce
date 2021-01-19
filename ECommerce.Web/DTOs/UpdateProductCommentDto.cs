using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.DTOs
{
    public class UpdateProductCommentDto
    {
        public bool IsApproved { get; set; }
        public string CommentText { get; set; }
    }
}
