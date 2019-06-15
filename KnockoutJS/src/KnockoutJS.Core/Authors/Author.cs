using System;
using System.Collections.Generic;
using KnockoutJS.Core.Books;
using System.Text;

namespace KnockoutJS.Core.Authors
{
    public class Author: Entity
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
