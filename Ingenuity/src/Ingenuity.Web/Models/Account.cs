using System;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public class Account
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Password { get; set; }
    }
}