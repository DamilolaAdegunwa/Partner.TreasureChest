using System.Collections.Generic;
using KnockoutJS.Core.CartItems;

namespace KnockoutJS.Core.Carts
{
    public class Cart : Entity
    {
        public string SessionId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
