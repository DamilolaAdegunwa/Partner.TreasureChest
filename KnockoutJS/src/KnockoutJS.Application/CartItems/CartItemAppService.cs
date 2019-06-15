﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍目录
    /// </summary>
    public class CartItemAppService : KnockoutJSAppServiceBase, ICartItemAppService
    {
        public readonly ICartItemRepository _cartItemRepository;

        public CartItemAppService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartItem> AddToCart(CartItem cartItem)
        {
            return await _cartItemRepository.AddToCart(cartItem);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
           _cartItemRepository.DeleteCartItem(cartItem);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
             _cartItemRepository.UpdateCartItem(cartItem);
        }
    }
}