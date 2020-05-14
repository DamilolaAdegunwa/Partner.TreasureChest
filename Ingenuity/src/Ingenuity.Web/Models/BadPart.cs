using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 不良品
    /// </summary>
    public class BadPart
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 零件加工Id
        /// </summary>
        public int PartProcessId { get; set; }

        /// <summary>
        /// 报废数量
        /// </summary>
        public int BadCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string ProcessName { get; set; }

        [NotMapped]
        public string MaterialName { get; set; }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}