using KnockoutJS.Core.Authors;
using KnockoutJS.Core.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.Core.Books
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class Book : Entity
    {
        /// <summary>
        /// 作者Id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// 类别Id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 书籍号
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// 大纲
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 批发价
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool Featured { get; set; }

        /// <summary>
        /// 关联作者
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// 关联类别
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
