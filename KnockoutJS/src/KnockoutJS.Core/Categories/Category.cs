using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.Categories
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
