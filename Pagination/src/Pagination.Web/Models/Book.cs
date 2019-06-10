using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Web.Models
{
    public class Book
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 书籍编号
        /// </summary>
        public string BookNumber { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 出版时间
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        public string Press { get; set; }
    }
}
