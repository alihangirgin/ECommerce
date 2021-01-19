using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface ICampaignSliderService
    {
        Task<IEnumerable<CampaignSlider>> GetCampaingList();
        Task<CampaignSlider> AddCampaing(CampaignSlider newCampaignSlider);
        Task<CampaignSlider> UpdateCampaing(CampaignSlider campaignSlider);
        Task DeleteCampaing(int id);
        Task<CampaignSlider> GetCampaingById(int id);

    }
}

