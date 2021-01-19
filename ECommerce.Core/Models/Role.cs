using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class Role : IdentityRole<int>, IEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
