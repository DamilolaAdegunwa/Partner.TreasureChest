using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 订单信息类
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 处理者
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string ModleNum { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 订单完成
        /// </summary>
        public bool IsComplete { get; set; } = false;

        /// <summary>
        /// 订单出货
        /// </summary>
        public bool IsShip { get; set; } = false;

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
        [NotMapped]
        public string T_IsComplete { get { return IsComplete ? "是" : "否"; } }
        [NotMapped]
        public string T_IsShip { get { return IsShip ? "是" : "否"; } }
    }
}
