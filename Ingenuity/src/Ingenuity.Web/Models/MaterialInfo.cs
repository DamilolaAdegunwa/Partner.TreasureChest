using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 物料信息
    /// </summary>
    public class MaterialInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 原材料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 使用数量
        /// </summary>
        public int UseCount { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 完成状态
        /// </summary>
        public int CompleteStatus { get; set; }

        [NotMapped]
        public string T_CompleteStatus
        {
            get
            {
                return Enum.GetName(typeof(CompleteStatusEnum), CompleteStatus);
            }
        }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }

    public enum CompleteStatusEnum : int
    {
        待加工 = 0,
        正加工 = 1,
        加工完成 = 2
    }
}