using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 出货
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId{ get; set; }

        /// <summary>
        /// 出货方式
        /// </summary>
        public string OutWay { get; set; }

        /// <summary>
        /// 出货人
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 出货数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}