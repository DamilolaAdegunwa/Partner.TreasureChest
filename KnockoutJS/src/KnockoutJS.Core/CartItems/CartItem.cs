using KnockoutJS.Core.Books;
using KnockoutJS.Core.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.CartItems
{
    public class CartItem : Entity
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Book Book { get; set; }
    }
}
