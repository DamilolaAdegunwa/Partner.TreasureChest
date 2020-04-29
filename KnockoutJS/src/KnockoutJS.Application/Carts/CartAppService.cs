using System;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.Carts;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 购物车服务
    /// </summary>
    public class CartAppService : KnockoutJSAppServiceBase, ICartAppService
    {
        private readonly ICartRepository _cartRepository;

        public CartAppService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetFirstCart()
        {
            var cart = await _cartRepository.GetFirstCart();
            return cart;
        }

        public async Task<Cart> GetByUserId(string userId)
        {
            var cart = await _cartRepository.GetByUserId(userId);
            return cart;
        }
    }
}
