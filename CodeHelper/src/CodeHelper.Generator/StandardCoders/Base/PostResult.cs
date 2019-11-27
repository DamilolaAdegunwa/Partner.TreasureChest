using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHelper.Generator.StandardCoder.Base
{
    /// <summary>
    /// 返回的通用类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PostResult<T>
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回消息代码
        /// </summary>
        public int? code { get; set; } = 0;

        /// <summary>
        /// 返回的数据，可以是Entity，也可以是List
        /// </summary>
        public T data { get; set; }

        public PostResult<T> Error(string _msg)
        {
            msg = _msg;
            return this;
        }
        public PostResult<T> Sucess(string _msg = "操作成功")
        {
            msg = _msg;
            return this;
        }
        public PostResult<T> Sucess(T t, string _msg = "操作成功")
        {
            msg = _msg;
            data = t;
            return this;
        }
    }

    /// <summary>
    /// 返回翻页类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PostResultList<T>
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回消息代码
        /// </summary>
        public int? code { get; set; } = 0;

        /// <summary>
        /// 返回的数据，可以是Entity，也可以是List
        /// </summary>
        public List<T> data { get; set; }

        /// <summary>
        /// 返回记录总条数
        /// </summary>
        public int total { get; set; }
      
    }
}