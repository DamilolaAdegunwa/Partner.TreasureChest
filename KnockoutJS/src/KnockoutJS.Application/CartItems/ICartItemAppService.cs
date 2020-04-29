using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 购物车子项应用服务接口
    /// </summary>
    public interface ICartItemAppService : IAppServiceBase
    {
        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task<CartItem> AddToCart(CartItem cartItem);

        /// <summary>
        /// 更新购物车子项信息
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task UpdateCartItem(CartItem cartItem);

        /// <summary>
        /// 删除购物车子项
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task DeleteCartItem(CartItem cartItem);
    }
}
