using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Service.DTOs;
using ECommerce.Web.DTOs;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CampaingSliderController : Controller
    {
        private readonly ICampaignSliderService _campaignSliderService;
        private readonly IMapper _mapper;
        public CampaingSliderController(ICampaignSliderService campaignSliderService, IMapper mapper)
        {
            _mapper = mapper;
            _campaignSliderService = campaignSliderService;

        }
        public async Task<IActionResult> CampaignSliderList()
        {
            var campaignSliders = await _campaignSliderService.GetCampaingList();
            var campaignSliderResources = _mapper.Map<IEnumerable<CampaignSlider>, IEnumerable<CampaignSliderViewModel>>(campaignSliders);
            return View(campaignSliderResources);
        }

        public async Task<IActionResult> NewCampaignSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewCampaignSlider(SaveCampaignSliderViewModel saveCampaignSliderVM)
        {
            var campaignSlider = _mapper.Map<SaveCampaignSliderViewModel, CampaignSlider>(saveCampaignSliderVM);
            await _campaignSliderService.AddCampaing(campaignSlider);
            return RedirectToAction("CampaignSliderList");
        }

        public async Task<IActionResult> DeleteCampaignSlider(int id)
        {
            await _campaignSliderService.DeleteCampaing(id);
            return RedirectToAction("ProductCategoryList");
        }

        public async Task<IActionResult> UpdateCampaignSlider(int id)
        {
            var campaignSlider = await _campaignSliderService.GetCampaingById(id);
            var updateCampaignSliderVM = _mapper.Map<CampaignSlider, CampaignSliderViewModel>(campaignSlider);
            return View(updateCampaignSliderVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCampaignSlider(UpdateCampaignSliderViewModel updateCampaignSliderVM)
        {
            var campaignSlider = _mapper.Map<UpdateCampaignSliderViewModel, CampaignSlider>(updateCampaignSliderVM);
            await _campaignSliderService.UpdateCampaing(campaignSlider);
            return RedirectToAction("ProductCategoryList");
        }


    }
}
