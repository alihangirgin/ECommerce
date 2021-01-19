using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Models
{
    public class CampaignSlider:Entity
    {
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
