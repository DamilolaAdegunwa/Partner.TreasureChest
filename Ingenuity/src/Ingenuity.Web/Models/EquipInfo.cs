using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public class EquipInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string EquipNumber { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 车间机位
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// 工作情况
        /// </summary>
        public string WorkSituation { get; set; }

        /// <summary>
        /// 运行状态
        /// </summary>
        public string OperateSituation { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}