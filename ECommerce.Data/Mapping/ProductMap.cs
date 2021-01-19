using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class ProductMap : Mapping<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Detail).IsRequired();
            builder.Property(x => x.CoverImage).HasMaxLength(250);
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
