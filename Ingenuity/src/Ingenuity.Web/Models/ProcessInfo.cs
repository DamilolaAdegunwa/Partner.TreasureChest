using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class ProcessInfo
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �����嵥Id
        /// </summary>
        public int MaterialInfoId { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public bool TechnologySituation { get; set; }

        /// <summary>
        /// �豸ID
        /// </summary>
        public int EquipInfoId { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_EquipNumber { get; set; }

        [NotMapped]
        public int CompleteStatus { get; set;}

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