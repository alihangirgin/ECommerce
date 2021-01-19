using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class ProductComment:Entity
    {
        public int UserId { get; set; }
        public int? ModeratorUserId { get; set; }
        public int ProductId { get; set; }
        public bool IsApproved { get; set; }
        public string CommentText { get; set; }
        public virtual User OwnerUser { get; set; }
        public virtual User ModeratorUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
