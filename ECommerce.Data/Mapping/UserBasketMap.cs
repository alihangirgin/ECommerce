using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class UserBasketMap : Mapping<UserBasket>
    {
        public override void Configure(EntityTypeBuilder<UserBasket> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserBaskets).HasForeignKey(x => x.UserId);
        }
    }
}
