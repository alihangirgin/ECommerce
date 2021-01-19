using ECommerce.Core.Models;
using ECommerce.Core.Repositories;
using ECommerce.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class CampaignSliderRepository: Repository<CampaignSlider>, ICampaignSliderRepository
    {
        public CampaignSliderRepository(ECommerceDbContext context):base(context)
        {
                    
        }
    }
}
