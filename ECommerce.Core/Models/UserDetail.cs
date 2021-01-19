using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class UserDetail : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nation { get; set; }
        public virtual User User { get; set; }
    }
}
