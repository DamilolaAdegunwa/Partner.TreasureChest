using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.Categories
{
    /// <summary>
    /// 类别
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 关联书籍
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
