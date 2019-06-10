using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// �豸״̬
    /// </summary>
    public class EquipInfo
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �豸���
        /// </summary>
        public string EquipNumber { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �����λ
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string WorkSituation { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        public string OperateSituation { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}