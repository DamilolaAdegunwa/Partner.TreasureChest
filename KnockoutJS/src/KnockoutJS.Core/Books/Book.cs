using KnockoutJS.Core.Authors;
using KnockoutJS.Core.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.Books
{
    public class Book : Entity
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Featured { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
