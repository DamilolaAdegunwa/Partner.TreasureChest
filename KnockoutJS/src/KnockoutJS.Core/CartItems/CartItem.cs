using KnockoutJS.Core.Books;
using KnockoutJS.Core.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.CartItems
{
    /// <summary>
    /// 购物车子项
    /// </summary>
    public class CartItem : Entity
    {
        /// <summary>
        /// 购物车Id
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// 书籍Id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// 书籍数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 关联购物车
        /// </summary>
        public virtual Cart Cart { get; set; }

        /// <summary>
        /// 关联书籍
        /// </summary>
        public virtual Book Book { get; set; }
    }
}
