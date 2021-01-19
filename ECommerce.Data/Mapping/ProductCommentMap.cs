using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class ProductCommentMap : Mapping<ProductComment>
    {
        public override void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.IsApproved).IsRequired();
            builder.Property(x => x.CommentText).IsRequired();

            builder.HasOne(x => x.ModeratorUser).WithMany(x => x.AcceptedProductComments).HasForeignKey(x => x.ModeratorUserId);
            builder.HasOne(x => x.OwnerUser).WithMany(x => x.AddedProductComments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductComments).HasForeignKey(x => x.ProductId);
        }
    }
}
