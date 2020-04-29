using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Core.Carts;
using KnockoutJS.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.EFCore.Repositories
{
    public class CartRepository : KnockoutJSRepositoryBase<Cart>, ICartRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;

        public CartRepository(ShoppingCartContext shoppingCartContext)
              : base(shoppingCartContext)
        {
            _shoppingCartContext = shoppingCartContext;
        }

        public async Task<Cart> GetFirstCart()
        {
            var cart = await _shoppingCartContext.Carts.FirstOrDefaultAsync();
            return cart;
        }

        public async Task<Cart> GetByUserId(string userId)
        {
            var cart = await _shoppingCartContext.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(c => c.Book)
                .Where(c => c.UserId == userId)
                .FirstOrDefaultAsync();

            cart = await CreateCartIfItDoesntExist(userId, cart);

            return cart;
        }

        private async Task<Cart> CreateCartIfItDoesntExist(string userId, Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                await _shoppingCartContext.Carts.AddAsync(cart);
                await _shoppingCartContext.SaveChangesAsync();
            }

            return cart;
        }
    }
}
