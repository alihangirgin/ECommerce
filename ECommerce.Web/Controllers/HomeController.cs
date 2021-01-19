using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ECommerce.Web.Models;
using ECommerce.Core.Services;
using AutoMapper;
using ECommerce.Web.DTOs;
using ECommerce.Core.Models;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICampaignSliderService _campaignSliderService;

        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductCategoryService productCategoryService, IMapper mapper, ICampaignSliderService campaignSliderService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _mapper = mapper;
            _campaignSliderService = campaignSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var campaignSliders = await _campaignSliderService.GetCampaingList();
            var campaignSliderResources = _mapper.Map<IEnumerable<CampaignSlider>, IEnumerable<CampaignSliderViewModel>>(campaignSliders);
            var homePageVM = new HomePageViewModel();
            homePageVM.CampaignSliderViewModels = campaignSliderResources.ToList();
            return View(homePageVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
