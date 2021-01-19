using AutoMapper;
using ECommerce.Core.DTOs;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
  
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            return await _unitOfWork.Products.GetAllAsync(x => x.DeleteDate == null);
        }

        public async Task<IEnumerable<Product>> GetProductListWithCategory()
        {
            var products = await _unitOfWork.Products.GetAllWithProductCategoryAsync(x => x.DeleteDate == null);
            foreach (var item in products)
            {
                var image = await GetProductCoverImageByProductId(item.Id);
                if(image !=null)
                {
                    item.CoverImage = image.FileName;
                }
            }
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductListByCategoryId(int categoryId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(x => x.CategoryId == categoryId && x.DeleteDate == null);
            foreach (var item in products)
            {
                var image = await GetProductCoverImageByProductId(item.Id);
                if (image != null)
                {
                    item.CoverImage = image.FileName;
                }
            }
            return products;
        }


        public async Task<IEnumerable<Product>> GetProductListByProductCategories(IEnumerable<ProductCategory> productCategories)
        {
            var productList = new List<Product>();
            foreach (var item in productCategories)
            {
                var products=await GetProductListByCategoryId(item.Id);
                if(products !=null)
                {
                    foreach (var subItem in products)
                    {
                        productList.Add(subItem);
                    }
                }
            }
            return productList;
        }

        public async Task<List<String>> GetProductsCoverImages()
        {
            var productList = await GetProductList();
            var imageList = new List<String>();
            foreach (var item in productList)
            {
                var image = await GetProductCoverImageByProductId(item.Id);
                imageList.Add(image.FileName);
            }
            return imageList;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            //newProduct.UserId = _userService.GetUser().Id; 
            newProduct.UserId = 1; // şimdilik 1
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products.GetAsync(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updatedProduct = await _unitOfWork.Products.UpdateProductAsync(product);
            await _unitOfWork.CommitAsync();
            return updatedProduct;
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
        }


        public async Task<IEnumerable<ProductDto>> SearchProduct(SearchProductDto searchProductResource)
        {
            var productListQuery = await GetProductList();
            if (searchProductResource.SearchText != null)
            {
                productListQuery = productListQuery.Where(x => x.Title.Contains(searchProductResource.SearchText));
            }
            if(searchProductResource.SearchType==3)
            {
                productListQuery = productListQuery.OrderBy(x => x.Price);
            }
            if (searchProductResource.SearchType == 4)
            {
                productListQuery = productListQuery.OrderByDescending(x => x.Price);
            }

            var searchProductResultResource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(productListQuery);

            return searchProductResultResource;
        }



        #region ProductComment
        public async Task<ProductComment> AddProductComment(ProductComment newProductComment, int productId)
        {
            var checkProduct = _unitOfWork.Products.GetAsync(x => x.Id == productId);
            //var userId = _userService.GetUser().Id;
            var userId = 1;//şimdilik 1
            //var checkProductComment = await _unitOfWork.ProductComments.GetAsync(x => x.UserId == userId && x.ProductId == productId);
            int? checkProductComment= null;//şimdilik
            if (checkProduct !=null && checkProductComment == null)
            {
                //newProduct.UserId = _userService.GetUser().Id; 
                newProductComment.ProductId = productId;
                newProductComment.UserId = 1; // şimdilik 1
                await _unitOfWork.ProductComments.AddAsync(newProductComment);
                await _unitOfWork.CommitAsync();
            }
            return newProductComment;
        }

        public async Task<ProductComment> GetProductCommentById(int id)
        {
            return await _unitOfWork.ProductComments.GetAsync(id);
        }

        public async Task<IEnumerable<ProductComment>> GetProductCommentList()
        {
            return await _unitOfWork.ProductComments.GetAllWithProductWithUserAsync();
        }

        public async Task<IEnumerable<ProductComment>> GetProductCommentListByProductId(int productId)
        {
            return await _unitOfWork.ProductComments.GetAllAsync(x => x.ProductId == productId && x.IsApproved == true);
        }

        public async Task<ProductComment> ApproveProductComment(int id)
        {
            var ProductCommentToBeApproved = await GetProductCommentById(id);
            if (ProductCommentToBeApproved != null)
            {
                if(ProductCommentToBeApproved.IsApproved == false)
                {
                    ProductCommentToBeApproved.IsApproved = true;
                    //productComment.ModeratorUserId = _userService.GetUser().Id;
                    ProductCommentToBeApproved.ModeratorUserId = 1;//şimdilik 1
                }
                else
                {
                    ProductCommentToBeApproved.IsApproved = false;
                    ProductCommentToBeApproved.ModeratorUserId = null;
                }
                ProductCommentToBeApproved.UpdateDate = DateTime.Now;
                await _unitOfWork.ProductComments.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            return ProductCommentToBeApproved;
        }

        public async Task<ProductComment> UpdateProductComment(ProductComment productComment, int id)
        {
            var productCommentToBeUpdate = await GetProductCommentById(id);
            if (productCommentToBeUpdate != null)
            {
                productCommentToBeUpdate.CommentText = productComment.CommentText;
                productCommentToBeUpdate.IsApproved = productComment.IsApproved;
                productCommentToBeUpdate.UpdateDate = DateTime.Now;
                await _unitOfWork.ProductComments.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            return productCommentToBeUpdate;
        }

        public async Task DeleteProductComment(int id)
        {
            var productCommentToBeDelete = await GetProductCommentById(id);
            if (productCommentToBeDelete != null)
            {
                productCommentToBeDelete.DeleteDate = DateTime.Now;
                await _unitOfWork.ProductComments.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
        }

        #endregion

        #region ProductImage
        public async Task<ProductImage> AddProductImage(ProductImage newProductImage, int productId)
        {
            //var userId = _userService.GetUser().Id;
            var userId = 1;//şimdilik 1
            var checkProduct = _unitOfWork.Products.GetAsync(x => x.Id == productId);
            if(checkProduct!=null)
            {
                //newProduct.UserId = _userService.GetUser().Id; 
                newProductImage.ProductId = productId;
                newProductImage.UserId = 1; // şimdilik 1
                await _unitOfWork.ProductImages.AddAsync(newProductImage);
                await _unitOfWork.CommitAsync();
            }
            return newProductImage;
        }

        public async Task<IEnumerable<ProductImage>> GetProductImageList()
        {
            return await _unitOfWork.ProductImages.GetAllWithProductAndUserAsync(x=>x.DeleteDate==null);
        }
        public async Task<ProductImage> GetProductImageById(int id)
        {
            return await _unitOfWork.ProductImages.GetAsync(id);
        }
        public async Task<ProductImage> GetProductCoverImageByProductId(int productId)
        {
            return await _unitOfWork.ProductImages.GetAsync(x => x.ProductId == productId && x.DeleteDate == null);
        }

        public async Task<IEnumerable<ProductImage>> GetProductImageListByProductId(int productId)
        {
            return await _unitOfWork.ProductImages.GetAllAsync(x => x.ProductId == productId && x.DeleteDate==null);
        }

        public async Task<IEnumerable<ProductImage>> GetProductImageListByProductIdIncludeDeleted(int productId)
        {
            return await _unitOfWork.ProductImages.GetAllAsync(x=>x.ProductId==productId);
        }

        public async Task DeleteProductImage(int id)
        {
            var productCommentToBeDelete = await GetProductImageById(id);
            if (productCommentToBeDelete != null)
            {
                productCommentToBeDelete.DeleteDate = DateTime.Now;
                await _unitOfWork.ProductComments.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
        }

        #endregion


    }
}
