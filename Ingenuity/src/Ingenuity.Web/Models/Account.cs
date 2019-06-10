using System;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}