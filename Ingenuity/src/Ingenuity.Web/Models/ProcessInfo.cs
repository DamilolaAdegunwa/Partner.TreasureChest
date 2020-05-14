using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 工序信息
    /// </summary>
    public class ProcessInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 物料清单Id
        /// </summary>
        public int MaterialInfoId { get; set; }

        /// <summary>
        /// 工序名
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 工艺情况
        /// </summary>
        public bool TechnologySituation { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public int EquipInfoId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_EquipNumber { get; set; }

        [NotMapped]
        public int CompleteStatus { get; set; }

        [NotMapped]
        public String MaterialName { get; set; }

        [NotMapped]
        public String OrderName { get; set; }

        [NotMapped]
        public string T_CompleteStatus { get { return Enum.GetName(typeof(CompleteStatusEnum), CompleteStatus); } }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}