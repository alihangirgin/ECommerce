using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class ProductCategory : Entity
    {
        public ProductCategory()
        {
            SubCategories = new Collection<ProductCategory>();
            Products = new Collection<Product>();
        }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual User User { get; set; }
        public virtual ProductCategory ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

