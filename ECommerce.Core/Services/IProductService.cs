using ECommerce.Core.DTOs;
using ECommerce.Core.Models;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductList();
        Task<IEnumerable<Product>> GetProductListWithCategory();
        Task<IEnumerable<Product>> GetProductListByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductListByProductCategories(IEnumerable<ProductCategory> productCategories);
        Task<List<String>> GetProductsCoverImages();
        Task<Product> AddProduct(Product newProduct);
        Task<Product> GetProductById(int id);
        Task DeleteProduct(int id);
        Task<Product> UpdateProduct(Product product);

        Task<IEnumerable<ProductDto>> SearchProduct(SearchProductDto searchProductResource);

        #region ProductComment
        Task<ProductComment> AddProductComment(ProductComment newProductComment, int productId);
        Task<ProductComment> GetProductCommentById(int id);
        Task<IEnumerable<ProductComment>> GetProductCommentList();
        Task<IEnumerable<ProductComment>> GetProductCommentListByProductId(int productId);
        Task<ProductComment> ApproveProductComment(int id);
        Task<ProductComment> UpdateProductComment(ProductComment productComment, int id);
        Task DeleteProductComment(int productCommentId);
        #endregion

        #region ProductImage
        Task<ProductImage> AddProductImage(ProductImage newProductImage, int productId);
        Task<IEnumerable<ProductImage>> GetProductImageList();
        Task<ProductImage> GetProductImageById(int id);
        Task<ProductImage> GetProductCoverImageByProductId(int productId);
        Task<IEnumerable<ProductImage>> GetProductImageListByProductId(int productId);
        Task<IEnumerable<ProductImage>> GetProductImageListByProductIdIncludeDeleted(int productId);
        Task DeleteProductImage(int id);

        #endregion
    }
}
