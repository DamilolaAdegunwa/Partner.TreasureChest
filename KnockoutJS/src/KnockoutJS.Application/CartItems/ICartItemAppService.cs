using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    public interface ICartItemAppService : IAppServiceBase
    {
        Task<CartItem> AddToCart(CartItem cartItem);

        void UpdateCartItem(CartItem cartItem);

        void DeleteCartItem(CartItem cartItem);
    }
}
