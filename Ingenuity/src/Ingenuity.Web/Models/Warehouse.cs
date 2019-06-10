using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ���
    /// </summary>
    public class Warehouse
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
        /// �������
        /// </summary>
        public DateTime InDate { get; set; }

        /// <summary>
        /// ���ӷ�ʽ
        /// </summary>
        public string TakeWay { get; set; }

        /// <summary>
        /// �ֿ���λ
        /// </summary>
        public string DepotSite { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// ��Ӧ��
        /// </summary>
        public string Supplier { get; set; }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string Contact { get; set; }

        [NotMapped]
        public string T_InDate { get { return InDate.ToString("yyyy-MM-dd HH:ss"); } }

    }
}