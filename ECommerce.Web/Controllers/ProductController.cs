using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DTOs;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductList()
        {
            var products = await _productService.GetProductListWithCategory();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductWithCategoryDto>>(products);
            return View(productResources);
        }

        public IActionResult NewProduct()
        {
            //kategori eklenecek
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct(SaveProductDto saveProductResource)
        {
            var product = _mapper.Map<SaveProductDto, Product>(saveProductResource);
            await _productService.AddProduct(product);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _productService.GetProductById(id);
            var productResource = _mapper.Map<Product, ProductWithProductCommentAndUserDto>(product);
            var productComments = await _productService.GetProductCommentListByProductId(id);
            var productImages = await _productService.GetProductImageListByProductId(id);
            productResource.ProductComments = _mapper.Map<IEnumerable<ProductComment>, IEnumerable<ProductCommentDto>>(productComments);
            productResource.ProductImages = _mapper.Map<IEnumerable<ProductImage>, IEnumerable<ProductImageDto>>(productImages);
            return View(productResource);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            var productResource = _mapper.Map<Product, UpdateProductDto>(product);
            return View(productResource);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductResource)
        {
            var product = _mapper.Map<UpdateProductDto, Product>(updateProductResource);
            await _productService.UpdateProduct(product);
            return RedirectToAction("ProductList");
        }

        //search eklenecek

        public IActionResult NewProductComment(int productId)
        {
            SaveProductCommentDto saveProductCommentResource = new SaveProductCommentDto();
            saveProductCommentResource.ProductId = productId;
            return View(saveProductCommentResource);
        }

        [HttpPost]
        public async Task<IActionResult> NewProductComment(SaveProductCommentDto saveProductCommentResource, int productId)
        {
            var productComment = _mapper.Map<SaveProductCommentDto, ProductComment>(saveProductCommentResource);
            await _productService.AddProductComment(productComment, productId);
            return RedirectToAction("ProductDetail", new { Id = productId }); //redirect product id
        }

        public async Task<IActionResult> ApproveProductComment(int id)
        {
            await _productService.ApproveProductComment(id);
            return RedirectToAction("ProductCommentList");
        }

        public async Task<IActionResult> ProductCommentList()
        {
            var productComments = await _productService.GetProductCommentList();
            var productCommentResource = _mapper.Map<IEnumerable<ProductComment>, IEnumerable<ProductCommentWithUserAndProducDto>>(productComments);
            return View(productCommentResource);
        }

        //unused
        public async Task<IActionResult> ProductComments(int productId)
        {
            var productComments = await _productService.GetProductCommentListByProductId(productId);
            var productCommentResource = _mapper.Map<IEnumerable<ProductComment>, IEnumerable<ProductCommentDto>>(productComments);
            return View(productCommentResource);
        }

        public async Task<IActionResult> ProductCommentDetail(int id)
        {
            var productComment = await _productService.GetProductCommentById(id);
            var productCommentResource = _mapper.Map<ProductComment, ProductCommentDto>(productComment);
            return View(productCommentResource);
        }

        public async Task<IActionResult> DeleteProductComment(int id)
        {
            await _productService.DeleteProductComment(id);
            return RedirectToAction("ProductCommentList");
        }

        public async Task<IActionResult> UpdateProductComment(int id)
        {
            var productComment = await _productService.GetProductCommentById(id);
            var productCommentResource = _mapper.Map<ProductComment, UpdateProductCommentDto>(productComment);
            return View(productCommentResource);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductComment(UpdateProductCommentDto updateProductCommentResource, int id)
        {
            var productComment = _mapper.Map<UpdateProductCommentDto, ProductComment>(updateProductCommentResource);
            await _productService.UpdateProductComment(productComment, id);
            return RedirectToAction("ProductCommentList");
        }


        public async Task<IActionResult> SearchProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchProduct(SearchProductViewModel searchProductViewModel)
        {
            var searchProductResource= _mapper.Map<SearchProductViewModel, SearchProductDto>(searchProductViewModel);
            var searchProductResultsResource = await _productService.SearchProduct(searchProductResource);
            var searchProductResultsViewModel= _mapper.Map<IEnumerable<Core.DTOs.ProductDto>, IEnumerable<ProductViewModel>>(searchProductResultsResource);
            return View(searchProductResultsViewModel);
        }


        public IActionResult NewProductImage(int productId)
        {
            SaveProductImageDto saveProductImageResource = new SaveProductImageDto();
            saveProductImageResource.ProductId = productId;
            return View(saveProductImageResource);
        }

        [HttpPost]
        public async Task<IActionResult> NewProductImage(SaveProductImageDto saveProductImageResource, int productId)
        {
            if (ModelState.IsValid && saveProductImageResource.ProductImageFile != null)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Errors.FirstOrDefault().ErrorMessage)).ToList();

                var uploadedFileExtension = Path.GetExtension(saveProductImageResource.ProductImageFile.FileName).ToLower();
                var acceptedFileExtensions = new List<string>()
                {
                        ".png",
                        ".jpg",
                        ".bmp",
                        ".jpeg"
                };

                //if it is not in defined file types
                if (!acceptedFileExtensions.Contains(uploadedFileExtension))
                {
                    errors.Add(new KeyValuePair<string, string>("FilePath", "Please select jpg, png or bmp file format"));

                    return RedirectToAction("ProductDetail", new { Id = productId });
                }
                var product = await _productService.GetProductById(saveProductImageResource.ProductId);
                if(product !=null)
                {
                    var productImageList = await _productService.GetProductImageListByProductIdIncludeDeleted(product.Id);
                    var imageNumber = productImageList.Count()+1;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductImages", (product.Title)+"."+(imageNumber)+saveProductImageResource.ProductImageFile.FileName.Replace(" ", "_") + "");
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        saveProductImageResource.ProductImageFile.CopyTo(stream);
                    }
                    saveProductImageResource.ImageUrl = path;
                    saveProductImageResource.FileName = (product.Title) + "." + (imageNumber) + saveProductImageResource.ProductImageFile.FileName.Replace(" ", "_") + "";

                    var productImage = _mapper.Map<SaveProductImageDto, ProductImage>(saveProductImageResource);
                    var checkErrors = await _productService.AddProductImage(productImage, saveProductImageResource.ProductId);
                    if (checkErrors !=null)
                    {
                        return RedirectToAction("ProductDetail", new { Id = productId });
                        //return Json(new { status= true, message = "Image was successfully added!", url = Url.Action("ProductDetail", new { Id = productId }) });
                    }
                    else
                    {
                        return RedirectToAction("ProductDetail", new { Id = productId });
                        //return Json(new { status = false, message = "Image couldn't be added!", url = Url.Action("ProductDetail", new { Id = productId }) });
                    }
                }
            }
            return RedirectToAction("ProductDetail", new { Id = productId });
            //return Json(new { status = false, message = "Image couldn't be added!", url = Url.Action("ProductDetail", new { Id = productId }) });
        }
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            await _productService.DeleteProductImage(id);
            return RedirectToAction("ProductList");
        }

        //public async Task<IActionResult> ProductImageList()
        //{
        //    return View();
        //}
    }
}
