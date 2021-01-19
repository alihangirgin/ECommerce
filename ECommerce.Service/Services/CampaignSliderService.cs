using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using ECommerce.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class CampaignSliderService: ICampaignSliderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CampaignSliderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }

        public async Task<IEnumerable<CampaignSlider>> GetCampaingList()
        {
            return await _unitOfWork.CampaignSliders.GetAllAsync(x => x.DeleteDate == null);
        }
        public async Task<CampaignSlider> AddCampaing(CampaignSlider newCampaignSlider)
        {
            await _unitOfWork.CampaignSliders.AddAsync(newCampaignSlider);
            await _unitOfWork.CommitAsync();
            return newCampaignSlider;
        }

        public async Task<Product> AddProduct(SaveProductDto saveProductResource)
        {
            var newProduct = _mapper.Map<SaveProductDto, Product>(saveProductResource);
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task<CampaignSlider> UpdateCampaing(CampaignSlider campaignSlider)
        {
            var updatedCampaignSlider = await _unitOfWork.CampaignSliders.UpdateAsync(campaignSlider);
            await _unitOfWork.CommitAsync();
            return updatedCampaignSlider;
        }

        public async Task DeleteCampaing(int id)
        {
            await _unitOfWork.CampaignSliders.DeleteAsync(id);
        }
        public async Task<CampaignSlider> GetCampaingById(int id)
        {
            return await _unitOfWork.CampaignSliders.GetAsync(id);
        }

    }
}
