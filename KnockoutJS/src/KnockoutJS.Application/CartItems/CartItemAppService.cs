using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 购物车子项应用服务
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

        public async Task DeleteCartItem(CartItem cartItem)
        {
            await _cartItemRepository.DeleteCartItem(cartItem);
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            await _cartItemRepository.UpdateCartItem(cartItem);
        }
    }
}
