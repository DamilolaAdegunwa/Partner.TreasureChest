using AutoMapper;
using KnockoutJS.Application;
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
            Console.WriteLine($"CartViewComponent InvokeAsync-Start ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            //设置Session中的属性，以此保证Session.Id是唯一的,否则session.Id总是变化的，参考官方文档
            HttpContext.Session.SetString("sessionId", HttpContext.Session.Id.ToString());
            var cart = await _cartAppService.GetBySessionId(HttpContext.Session.Id);
            var cartViewModel = _mapper.Map<CartViewModel>(cart);
            Console.WriteLine($"CartViewComponent InvokeAsync-End ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            return View(cartViewModel);
        }
    }
}
