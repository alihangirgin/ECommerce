using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.ViewComponents
{
    public class NavBarDefaultViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        public NavBarDefaultViewComponent(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            var mainCategories = await _productCategoryService.GetMainCategories();
            var productCategoriesResource = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(mainCategories);
            if (productCategoriesResource != null)
            {
                foreach (var item in productCategoriesResource)
                {
                    var newSubCategoryTree = new List<ProductCategory>();
                    var sub = await _productCategoryService.Deneme(item.Id, newSubCategoryTree);
                    var subResource = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(sub);
                    item.SubCategories = subResource;
                }
            }
            MainBarViewModel mainBarViewModel = new MainBarViewModel();
            mainBarViewModel.ProductCategories = productCategoriesResource;
            return View(mainBarViewModel);

            //var mainCategories = await _productCategoryService.GetMainCategories();
            //var productCategoryList = new List<ProductCategory>();
            //foreach (var item in mainCategories)
            //{
            //    var productCategory = await _productCategoryService.GetProductCategoryById(item.Id);
            //    productCategoryList.Add(productCategory);
            //}
            //var productCategoriesResource = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(productCategoryList);
            //return View(productCategoriesResource);



        }
    }
}
