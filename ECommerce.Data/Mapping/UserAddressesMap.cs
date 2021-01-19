using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class UserAddressesMap :Mapping<UserAddresses>
    {
        public override void Configure(EntityTypeBuilder<UserAddresses> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.DefaultAddress).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(150);
            builder.Property(x => x.AddressText);

            builder.HasOne(x => x.User).WithMany(x => x.UserAddresses).HasForeignKey(x => x.UserId);
        }
    }
}
