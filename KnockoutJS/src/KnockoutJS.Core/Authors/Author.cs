using System;
using System.Collections.Generic;
using KnockoutJS.Core.Books;
using System.Text;

namespace KnockoutJS.Core.Authors
{
    /// <summary>
    /// 作者
    /// </summary>
    public class Author : Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// 关联书籍
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
