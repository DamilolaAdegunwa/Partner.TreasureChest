using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ����Ʒ
    /// </summary>
    public class WorkingProductInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����Id
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Ŀ������
        /// </summary>
        public string AimCount { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string FinishCount { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string DifferCount { get; set; }

        [NotMapped]
        public string OrderName { get; set; }

        [NotMapped]
        public string MaterialName { get; set; }
    }
}