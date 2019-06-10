using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ����Ʒ
    /// </summary>
    public class BadPart
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����ӹ�Id
        /// </summary>
        public int PartProcessId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int BadCount { get; set; }

        /// <summary>
        /// ����ʱ��
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