using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.DTOs;
using ECommerce.Web.DTOs;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SaveProductDto, Product>();
            CreateMap<Product, SaveProductDto>();

            CreateMap<SaveProductDto, Product>();
            CreateMap<Product, SaveProductDto>();

            CreateMap<DTOs.ProductDto, Product>();
            CreateMap<Product, DTOs.ProductDto>();

            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();

            CreateMap<DTOs.ProductDto, ProductCategory>();
            CreateMap<ProductCategory, DTOs.ProductDto>();


            CreateMap<SaveProductCommentDto, ProductComment>();
            CreateMap<ProductComment, ProductCommentWithUserAndProducDto>();
            CreateMap<Product, ProductWithProductCommentAndUserDto>();
            CreateMap<ProductComment, UpdateProductCommentDto>();
            CreateMap<ProductComment, ProductCommentDto>();
            CreateMap<UpdateProductCommentDto, ProductComment>();
            CreateMap<SaveProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<ProductCategory, SaveProductCategoryDto>();
            CreateMap<ProductCategory, UpdateProductCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryWithParentCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryWithParentAndSubCategories>();
            CreateMap<SaveProductCategoryDto, ProductCategory>();
            CreateMap<UpdateProductCategoryDto, ProductCategory>();
            CreateMap<ProductCategory,  List < SelectListItem >> ();

            CreateMap<SaveCampaignSliderViewModel, CampaignSlider>();
            CreateMap<CampaignSlider, CampaignSliderViewModel>();
            CreateMap<UpdateCampaignSliderViewModel, CampaignSlider>();

            CreateMap<BasketProduct, BasketProductDto>();
            CreateMap<BasketProduct, BasketProductWithProductsDto>();



            CreateMap<SearchProductViewModel, SearchProductDto>();
            CreateMap<Core.DTOs.ProductDto, ProductViewModel>();
            CreateMap<Product, Core.DTOs.ProductDto>();


        }
    }
}
