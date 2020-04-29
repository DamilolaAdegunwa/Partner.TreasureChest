using KnockoutJS.Core;
using KnockoutJS.Core.CartItems;
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
    public class CartItemRepository : KnockoutJSRepositoryBase<CartItem>, ICartItemRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;

        public CartItemRepository(ShoppingCartContext shoppingCartContext)
              : base(shoppingCartContext)
        {
            _shoppingCartContext = shoppingCartContext;
        }

        public async Task<CartItem> AddToCart(CartItem cartItem)
        {
            var existingCartItem = await GetByCartIdAndBookId(cartItem.CartId, cartItem.BookId);

            if (existingCartItem == null)
            {
                _shoppingCartContext.Entry(cartItem).State = EntityState.Added;
                existingCartItem = cartItem;
            }
            else
            {
                existingCartItem.Quantity = cartItem.Quantity;
            }

            _shoppingCartContext.SaveChanges();

            return existingCartItem;
        }

        public async Task DeleteCartItem(CartItem cartItem)
        {
            _shoppingCartContext.Entry(cartItem).State = EntityState.Deleted;
            await _shoppingCartContext.SaveChangesAsync();
        }

        public async Task<CartItem> GetByCartIdAndBookId(int cartId, int bookId)
        {
            return await _shoppingCartContext.CartItems.FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.BookId == bookId);
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            _shoppingCartContext.Entry(cartItem).State = EntityState.Modified;
            await _shoppingCartContext.SaveChangesAsync();
        }
    }
}
