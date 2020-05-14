using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// 入库
    /// </summary>
    public class Warehouse
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
        /// 入库日期
        /// </summary>
        public DateTime InDate { get; set; }

        /// <summary>
        /// 交接方式
        /// </summary>
        public string TakeWay { get; set; }

        /// <summary>
        /// 仓库区位
        /// </summary>
        public string DepotSite { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        [NotMapped]
        public string T_InDate { get { return InDate.ToString("yyyy-MM-dd HH:ss"); } }

    }
}