using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace ECommerce.Service.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryList()
        {
            return await _unitOfWork.ProductCategories.GetAllAsync(x => x.DeleteDate == null);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryListWithParentCategory()
        {
            return await _unitOfWork.ProductCategories.GetAllWithParentCategoryAsync(x => x.DeleteDate == null);
        }

        public async Task<List<SelectListItem>> GetProductCategoryListToForm()
        {
            var categoryList = new List<SelectListItem>();
            var productCategories = await GetProductCategoryListWithParentCategory();
            productCategories.ToList().ForEach(x =>
            {
                categoryList.Add(new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                });

            });
            return categoryList;
        }

        public async Task<ProductCategory> AddProductCategory(ProductCategory newProductCategory)
        {
            //newProduct.UserId = _userService.GetUser().Id; 
            newProductCategory.UserId = 1; // şimdilik 1
            await _unitOfWork.ProductCategories.AddAsync(newProductCategory);
            await _unitOfWork.CommitAsync();
            return newProductCategory;
        }

        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            return await _unitOfWork.ProductCategories.GetWithParentCategoryAsync(id);
        }
        public async Task<ProductCategory> GetProductCategoryById(int? id)
        {
            return await _unitOfWork.ProductCategories.GetWithParentCategoryAsync(id);
        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            var updatedProduct = await _unitOfWork.ProductCategories.UpdateProductCategoryAsync(productCategory);
            await _unitOfWork.CommitAsync();
            return updatedProduct;
        }

        public async Task DeleteProductCategory(int id)
        {
            await _unitOfWork.ProductCategories.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetMainCategories()
        {
            return await _unitOfWork.ProductCategories.GetAllAsync(x => x.CategoryId == null && x.DeleteDate == null);
        }

        //public async Task<IEnumerable<ProductCategory>> GetMainCategoriesWithSubCategories()
        //{
        //    var mainCategories = await GetMainCategories();
        //    if(mainCategories !=null)
        //    {
        //        foreach (var item in mainCategories)
        //        {

        //            var newSubCategoryTree = new List<ProductCategory>();
        //            var sub = await GetSubCategoryTree(item.Id,newSubCategoryTree);
        //            item.SubCategories = sub;
        //        }
        //    }
        //}

        public async Task<IEnumerable<ProductCategory>> GetParentCategoryTree(int? productCategoryId, List<ProductCategory> productCategoryTree)
        {
            var productCategory = await GetProductCategoryById(productCategoryId);
            if (productCategory.CategoryId != null)
            {
                var parentCategory = await GetProductCategoryById(productCategory.CategoryId);
                productCategoryTree.Add(parentCategory);
                await GetParentCategoryTree(productCategory.CategoryId, productCategoryTree);
            }

            return productCategoryTree;
        }

        public async Task<IEnumerable<ProductCategory>> GetParentCategoryList(int id)
        {
            var newParentCategoryTree = new List<ProductCategory>();
            var parentCategoryTree = await GetParentCategoryTree(id, newParentCategoryTree);
            parentCategoryTree = parentCategoryTree.Reverse().ToList();
            return parentCategoryTree;        
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryAndParentCategoryList(int id)
        {
            var newParentCategoryTree = new List<ProductCategory>();
            var currentCategory = await GetProductCategoryById(id);
            newParentCategoryTree.Add(currentCategory);
            var parentCategoryTree = await GetParentCategoryTree(id, newParentCategoryTree);
            parentCategoryTree = parentCategoryTree.Reverse().ToList();
            return parentCategoryTree;
        }

        public async Task<IEnumerable<ProductCategory>> GetSubCategoriesById(int id)
        {
            return await _unitOfWork.ProductCategories.GetAllAsync(x => x.CategoryId == id && x.DeleteDate == null);
        }


        public async Task<IEnumerable<ProductCategory>> Deneme(int productCategoryId, List<ProductCategory> productCategoryTree)
        {
            var subCategories = await GetSubCategoriesById(productCategoryId);
            foreach (var item in subCategories)
            {
                //item.SubCategories.Add(item);
                //productCategoryTree.Add(item);
                await Deneme(item.Id, productCategoryTree);
            }

            return subCategories;
        }

        public async Task<IEnumerable<ProductCategory>> GetSubCategoryTree(int productCategoryId, List<ProductCategory> productCategoryTree)
        {
            var subCategories = await GetSubCategoriesById(productCategoryId);
            foreach (var item in subCategories)
            {
                productCategoryTree.Add(item);
                await GetSubCategoryTree(item.Id, productCategoryTree);
            }

            return productCategoryTree;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoryAndSubCategoryList(int id)
        {
            var productCategoryTree = new List<ProductCategory>();
            var currentCategory = await GetProductCategoryById(id);
            productCategoryTree.Add(currentCategory);
            var newSubCategoryTree = new List<ProductCategory>();
            var subCategoryTree = await GetSubCategoryTree(id, newSubCategoryTree);
            if (subCategoryTree != null)
            {
                foreach (var item in subCategoryTree)
                {
                    productCategoryTree.Add(item);
                }
            }

            return productCategoryTree;
        }


    }
}
