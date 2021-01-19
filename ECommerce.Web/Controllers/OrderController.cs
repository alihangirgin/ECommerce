using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Models;
using ECommerce.Core.Services;
using ECommerce.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        public OrderController(IProductCategoryService productCategoryService, IProductService productService, IMapper mapper, IOrderService orderService, IBasketService basketService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _mapper = mapper;
            _orderService = orderService;
            _basketService = basketService;
        }

        public async Task<IActionResult> NewOrder()
        {
            var basketProducts = await _basketService.GetUsersBasketProducts();
            var basketProductsResources = _mapper.Map<IEnumerable<BasketProduct>, IEnumerable<BasketProductWithProductsDto>>(basketProducts);
            
            return View(basketProductsResources);
        }

        [HttpPost]
        public async Task<IActionResult> NewOrder(int x=0)
        {
            return View();
        }


        public async Task<IActionResult> Payment()
        {
            return View();
        }

        public async Task<IActionResult> MyOrderList()
        {
            return View();
        }
    }
}
