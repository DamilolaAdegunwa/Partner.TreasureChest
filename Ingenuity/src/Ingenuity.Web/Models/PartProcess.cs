using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingenuity.Web.Models
{
    /// <summary>
    /// ���ϼӹ�
    /// </summary>
    public class PartProcess
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
        /// ���մ�����
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate { get; set; }

        [NotMapped]
        public string T_CreateDate { get { return CreateDate.ToString("yyyy-MM-dd HH:ss"); } }
    }
}