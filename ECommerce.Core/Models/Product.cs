using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Core.Models
{
    public class Product:Entity
    {
        public Product()
        {
            ProductImages = new Collection<ProductImage>();
            ProductComments = new Collection<ProductComment>();
            BasketProducts = new Collection<BasketProduct>();
        }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string CoverImage { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
