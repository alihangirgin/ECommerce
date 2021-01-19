using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.DTOs
{
    public class UpdateCampaignSliderDto
    {
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
