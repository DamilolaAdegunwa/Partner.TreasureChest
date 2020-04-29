using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Core;
using KnockoutJS.Web.Extensions;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutJS.Web.Controllers
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartController : Controller
    {
        private readonly ICartAppService _cartAppService;
        private readonly IMapper _mapper;

        public CartController(ICartAppService cartAppService, IMapper mapper)
        {
            _cartAppService = cartAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartAppService.GetByUserId(CommonData.UserId);
            var cartViewModel = _mapper.Map<CartViewModel>(cart);
            return View(cartViewModel);
        }
    }
}