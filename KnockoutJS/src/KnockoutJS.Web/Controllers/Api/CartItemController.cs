using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutJS.Web.Controllers.Api
{
    /// <summary>
    /// 购物车子项
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemAppService _cartItemAppService;
        private readonly IMapper _mapper;

        public CartItemController(ICartItemAppService cartItemAppService, IMapper mapper)
        {
            _cartItemAppService = cartItemAppService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<CartItemViewModel> Post(CartItemViewModel cartItem)
        {
            var newCartItem = _mapper.Map<CartItem>(cartItem);
            newCartItem = await _cartItemAppService.AddToCart(newCartItem);
            cartItem = _mapper.Map<CartItemViewModel>(newCartItem);
            return cartItem;
        }

        [HttpPut]
        [Route("Put")]
        public void Put(CartItemViewModel cartItem)
        {
            var newCartItem = _mapper.Map<CartItem>(cartItem);
            _cartItemAppService.UpdateCartItem(newCartItem);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(CartItemViewModel cartItem)
        {
            var newCartItem = _mapper.Map<CartItem>(cartItem);
            _cartItemAppService.DeleteCartItem(newCartItem);
        }
    }
}