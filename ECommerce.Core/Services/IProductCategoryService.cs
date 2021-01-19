using ECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Core.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoryList();
        Task<IEnumerable<ProductCategory>> GetProductCategoryListWithParentCategory();
        Task<List<SelectListItem>> GetProductCategoryListToForm();
        Task<ProductCategory> AddProductCategory(ProductCategory newProductCategory);
        Task<ProductCategory> GetProductCategoryById(int id);
        Task<ProductCategory> GetProductCategoryById(int? id);
        Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(int id);
        Task<IEnumerable<ProductCategory>> GetMainCategories();
        Task<IEnumerable<ProductCategory>> GetParentCategoryTree(int? productCategoryId, List<ProductCategory> productCategoryTree);
        Task<IEnumerable<ProductCategory>> GetParentCategoryList(int id);
        Task<IEnumerable<ProductCategory>> GetProductCategoryAndParentCategoryList(int id);
        Task<IEnumerable<ProductCategory>> GetSubCategoriesById(int id);
        Task<IEnumerable<ProductCategory>> GetSubCategoryTree(int productCategoryId, List<ProductCategory> productCategoryTree);
        Task<IEnumerable<ProductCategory>> GetProductCategoryAndSubCategoryList(int id);
        Task<IEnumerable<ProductCategory>> Deneme(int productCategoryId, List<ProductCategory> productCategoryTree);
    }
}
