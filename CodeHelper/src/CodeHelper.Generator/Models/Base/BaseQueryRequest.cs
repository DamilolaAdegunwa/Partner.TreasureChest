using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHelper.Models.Base
{
    /// <summary>
    /// Get方式父类
    /// </summary>
    public class BaseQueryRequest
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        public int pagesize { get; set; } = 10;

        /// <summary>
        /// 当前页
        /// </summary>
        public int pageindex { get; set; } = 1;

        /// <summary>
        /// 需要排序的字段
        /// </summary>
        public string sortcloumn { get; set; } = "id";

        /// <summary>
        /// asc，还是 desc，忽略大小写
        /// </summary>
        public string sortdirection { get; set; } = "asc";
    }
}