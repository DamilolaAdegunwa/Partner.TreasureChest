using System.Collections.Generic;
using KnockoutJS.Core.CartItems;

namespace KnockoutJS.Core.Carts
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class Cart : Entity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 关联购物车子项
        /// </summary>
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
