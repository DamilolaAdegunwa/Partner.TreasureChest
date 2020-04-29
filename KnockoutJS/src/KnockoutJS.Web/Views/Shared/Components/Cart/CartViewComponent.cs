using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Web.Extensions;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartAppService _cartAppService;
        private readonly IMapper _mapper;

        public CartViewComponent(ICartAppService cartAppService, IMapper mapper)
        {
            _cartAppService = cartAppService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await _cartAppService.GetByUserId(CommonData.UserId);
            var cartViewModel = _mapper.Map<CartViewModel>(cart);
            return View(cartViewModel);
        }
    }
}
