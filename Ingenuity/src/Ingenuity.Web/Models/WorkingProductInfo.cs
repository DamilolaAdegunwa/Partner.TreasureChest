using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 在制品
    /// </summary>
    public class WorkingProductInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 目标数量
        /// </summary>
        public string AimCount { get; set; }

        /// <summary>
        /// 完成数量
        /// </summary>
        public string FinishCount { get; set; }

        /// <summary>
        /// 差额数量
        /// </summary>
        public string DifferCount { get; set; }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string MaterialName { get; set; }
    }
}