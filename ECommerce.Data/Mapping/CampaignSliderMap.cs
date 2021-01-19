using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Mapping
{
    public class CampaignSliderMap :Mapping<CampaignSlider>
    {
        public override void Configure(EntityTypeBuilder<CampaignSlider> builder)
        {
            builder.Property(x => x.ImageUrl).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
