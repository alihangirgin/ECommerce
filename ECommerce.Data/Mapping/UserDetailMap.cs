using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class UserDetailMap : Mapping<UserDetail>
    {
        public override void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BirthDate);
            builder.Property(x => x.Nation).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.User).WithOne(x => x.UserDetail).HasForeignKey<UserDetail>(x => x.UserId);
        }
    }
}
