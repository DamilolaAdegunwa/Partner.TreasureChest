using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 材料加工
    /// </summary>
    public class PartProcess
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
        /// 工艺处理者
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// 完成总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}