using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class OrderMap : Mapping<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Tax).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.PaymentStatus).IsRequired();
            builder.Property(x => x.PaymentType).IsRequired();

            builder.HasOne(x => x.UserBasket).WithMany(x => x.Orders).HasForeignKey(x => x.UserBasketId);
            builder.HasOne(x => x.DeliveryAddress).WithMany(x => x.OrderByDeliveryAddress).HasForeignKey(x => x.DeliveryAddressId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.InvoiceAddress).WithMany(x => x.OrderByInvoiceAddress).HasForeignKey(x => x.InvoiceAddressId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
