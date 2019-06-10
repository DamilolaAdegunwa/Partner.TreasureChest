using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ����
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string OrderId{ get; set; }

        /// <summary>
        /// ������ʽ
        /// </summary>
        public string OutWay { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}