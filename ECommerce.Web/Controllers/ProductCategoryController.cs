using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductCategoryController(IProductCategoryService productCategoryService, IProductService productService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> ProductCategoryList()
        {
            var productCategories = await _productCategoryService.GetProductCategoryListWithParentCategory();
            var productCategoryResources = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryWithParentCategoryDto>>(productCategories);
            return View(productCategoryResources);
        }

        public async Task<IActionResult> NewProductCategory()
        {
            var categoryList = await _productCategoryService.GetProductCategoryListToForm();
            var saveProductCategoryResource = new SaveProductCategoryDto();
            saveProductCategoryResource.ProductCategoryList = categoryList;
            return View(saveProductCategoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> NewProductCategory(SaveProductCategoryDto saveProductCategoryResource)
        {
            var productCategory = _mapper.Map<SaveProductCategoryDto, ProductCategory>(saveProductCategoryResource);
            await _productCategoryService.AddProductCategory(productCategory);
            return RedirectToAction("ProductCategoryList");
        }
        public async Task<IActionResult> ProductCategoryDetail(int id)
        {
            var productCategory = await _productCategoryService.GetProductCategoryById(id);
            var productCategoryResource = _mapper.Map<ProductCategory, ProductCategoryWithParentAndSubCategories>(productCategory);
            var subCategories = await _productCategoryService.GetSubCategoriesById(id);
            var subCategoriesResource = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(subCategories);
            productCategoryResource.SubCategories = subCategoriesResource;
            var parentCategoryTree = await _productCategoryService.GetProductCategoryAndParentCategoryList(id);
            var parentCategoriesResource = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(parentCategoryTree);
            productCategoryResource.ParentCategories = parentCategoriesResource;


            var subCategoryTree = await _productCategoryService.GetProductCategoryAndSubCategoryList(id);
            var products = await _productService.GetProductListByProductCategories(subCategoryTree);
            var productsResource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            productCategoryResource.Products = productsResource;

            return View(productCategoryResource);
        }
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            await _productCategoryService.DeleteProductCategory(id);
            return RedirectToAction("ProductCategoryList");
        }

        public async Task<IActionResult> UpdateProductCategory(int id)
        {
            var productCategory = await _productCategoryService.GetProductCategoryById(id);
            var updateProductCategoryResource = _mapper.Map<ProductCategory, UpdateProductCategoryDto>(productCategory);
            var categoryList = await _productCategoryService.GetProductCategoryListToForm();
            updateProductCategoryResource.ProductCategoryList = categoryList;

            return View(updateProductCategoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryDto updateProductCategoryResource)
        {
            var productCategory = _mapper.Map<UpdateProductCategoryDto, ProductCategory>(updateProductCategoryResource);
            await _productCategoryService.UpdateProductCategory(productCategory);
            return RedirectToAction("ProductCategoryList");
        }

        public async Task<IActionResult> GetEverything()
        {
            var parentCategory = await _productCategoryService.GetProductCategoryById(1002);
            var productCategoryTree = new List<ProductCategory>();
            var result = await _productCategoryService.GetSubCategoryTree(1002, productCategoryTree);
            var result2 = await _productCategoryService.GetProductCategoryList();
            
            
            var result3 = await _productCategoryService.GetProductCategoryAndSubCategoryList(1002);
            var x = 0;
            
            var y = 0;
            return View();
        }

    }
}
