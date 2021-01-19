using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class BasketProductMap : Mapping<BasketProduct>
    {
        public override void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.Property(x => x.ProductCount).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.BasketProducts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.UserBasket).WithMany(x => x.BasketProducts).HasForeignKey(x => x.UserBasketId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
