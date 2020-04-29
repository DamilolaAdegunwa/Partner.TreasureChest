using KnockoutJS.Core.CartItems;
using System.Threading.Tasks;

namespace KnockoutJS.Core.IRepositories
{
    public interface ICartItemRepository: IRepositoryBase<CartItem>
    {
        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task<CartItem> AddToCart(CartItem cartItem);

        /// <summary>
        /// 更新购物车子项
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
