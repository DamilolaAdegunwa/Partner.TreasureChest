using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 库存信息
    /// </summary>
    public class InventoryInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 仓库区位
        /// </summary>
        public string DepotSite { get; set; }

        /// <summary>
        /// 总量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 余量
        /// </summary>
        public int RemainCount { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        [NotMapped]
        public string T_UpdateDate { get { return UpdateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}