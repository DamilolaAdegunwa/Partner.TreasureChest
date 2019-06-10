using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// �����Ϣ
    /// </summary>
    public class InventoryInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// �ֿ���λ
        /// </summary>
        public string DepotSite { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int RemainCount { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }

        [NotMapped]
        public string T_UpdateDate { get { return UpdateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}